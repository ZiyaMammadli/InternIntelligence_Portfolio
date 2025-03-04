using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Auth;

public class UserAlreadyExistException:BaseException
{
    public UserAlreadyExistException() { }
    public UserAlreadyExistException(string message) : base(message) { }
    public UserAlreadyExistException(int StatusCode, string message) : base(StatusCode, message) { }
}
