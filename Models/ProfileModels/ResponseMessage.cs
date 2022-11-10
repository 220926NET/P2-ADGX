namespace Models;
public class ResponseMessage<T>
{
    public T? data { get; set; }
    public string message { get; set; } = string.Empty;

    public Boolean success { get; set; } = false;
}