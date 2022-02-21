namespace ReportService.Utilities.Result
{
    public class ResultModel<T> : IResultModel<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class ResultModel : IResultModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }


}
