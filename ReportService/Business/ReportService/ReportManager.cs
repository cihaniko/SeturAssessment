using ReportService.DataAccess.Repositories.Abstract;
using ReportService.Entities.Concrete;
using ReportService.Entities.Dto;
using ReportService.Utilities.Constants;
using ReportService.Utilities.Result;
using System.Text.Json;

namespace ReportService.Business.ReportService
{
    public class ReportManager : IReportManager
    {
        private readonly IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            this._reportDal = reportDal;
        }

        public async Task<ResultModel<List<ReportDto>>> StatisticReportByAllLocation()
        {
            List<ReportDto> reportList = new List<ReportDto>();

            using var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7045/api/ContactsDetails/GetAll");
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var result = JsonSerializer.Deserialize<ResultModel<List<ContactDetails>>>(response.Content.ReadAsStringAsync().Result, serializeOptions);

            if (!result.IsSuccess)
            {
                return new ResultModel<List<ReportDto>>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = reportList };

            }

            var locationGroups = result.Data.
                                Where(s => !string.IsNullOrEmpty(s.Location)).
                                GroupBy(s => s.Location).ToList();


            foreach (var locationGroup in locationGroups)
            {
                var phoneCount = locationGroup.ToList().Where(s => !string.IsNullOrEmpty(s.Telephone)).DistinctBy(d => d.Telephone).Count();
                var contactCount = locationGroup.ToList().DistinctBy(d => d.ContactId).Count();
                var report = new ReportDto
                {
                    Location = locationGroup.Key,
                    ContactCount = contactCount,
                    PhoneCount = phoneCount
                };
                reportList.Add(report);
            }

            return new ResultModel<List<ReportDto>>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = reportList };
        }

    }
}
