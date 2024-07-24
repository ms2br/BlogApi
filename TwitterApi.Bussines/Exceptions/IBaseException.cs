namespace TwitterApi.Bussines.Exceptions;

public interface IBaseException
{
    public int StatusCode { get; }
    public string ExceptionMessage { get; set; }
}
