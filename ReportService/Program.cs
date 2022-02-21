using ReportService.Business.ReportService;
using ReportService.Business.ReportStatusService;
using ReportService.DataAccess.Core;
using ReportService.DataAccess.Repositories.Abstract;
using ReportService.DataAccess.Repositories.Concrete;
using ReportService.Utilities.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(options =>
{
    options.ConnectionString = builder.Configuration
        .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.ConnectionStringValue).Value;
    options.DatabaseName = builder.Configuration
        .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.DatabaseValue).Value;
});

// Add services to the container.
builder.Services.AddSingleton<IReportManager, ReportManager>();
builder.Services.AddSingleton<IReportDal, ReportsRepository>();
builder.Services.AddSingleton<IReportStatusManager, ReportStatusManager>();
builder.Services.AddSingleton<IReportStatusDal, ReportStatusRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<RabbitMqConsumerHelper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
