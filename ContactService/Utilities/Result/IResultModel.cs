namespace ContactService.Utilities.Result
{
    public interface IResultModel
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }

    }
    public interface IResultModel<T>:IResultModel
    {
        T? Data { get; set; }    

    }
}