namespace Domain.Exceptions;

public class InvalidRequestBodyException : Exception
{
    public string[] Errors { get; set; }
}
