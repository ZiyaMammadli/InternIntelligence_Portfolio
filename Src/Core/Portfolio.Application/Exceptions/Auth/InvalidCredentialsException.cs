using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Auth;

public class InvalidCredentialsException:BaseException
{
    public InvalidCredentialsException() { }
    public InvalidCredentialsException(string message) : base(message) { }
    public InvalidCredentialsException(int StatusCode, string message) : base(StatusCode, message) { }
}
