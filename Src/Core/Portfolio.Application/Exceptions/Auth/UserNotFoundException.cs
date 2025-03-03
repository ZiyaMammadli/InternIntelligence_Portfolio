using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Auth;

public class UserNotFoundException:BaseException
{
    public UserNotFoundException() { }
    public UserNotFoundException(string message):base(message) { }
    public UserNotFoundException(int StatusCode,string message):base(StatusCode,message) { }
}
