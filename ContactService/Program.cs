using ContactService.Business.ContactDetailsService;
using ContactService.Business.ContactService;
using ContactService.DataAccess.Core;
using ContactService.DataAccess.Core.Context;
using ContactService.DataAccess.Repositories.Abstract;
using ContactService.DataAccess.Repositories.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(options =>
{
    options.ConnectionString = builder.Configuration
        .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.ConnectionStringValue).Value;
    options.DatabaseName = builder.Configuration
        .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.DatabaseValue).Value;
});

builder.Services.Configure<DatabaseSettings>(
        builder.Configuration.GetSection("MongoConnection"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<MongoDBContext>();

builder.Services.AddSingleton<IContactManager, ContactManager>();
builder.Services.AddSingleton<IContactDal, ContactRepository>();
builder.Services.AddSingleton<IContactDetailsDal, ContactDetailsRepository>();
builder.Services.AddSingleton<IContactDetailsManager, ContactDetailsManager>();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{


    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultControllerRoute();

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
