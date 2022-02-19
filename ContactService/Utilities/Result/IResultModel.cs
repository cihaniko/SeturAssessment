namespace ContactService.Utilities.Result
{
    public interface IResultModel
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }

    }
}