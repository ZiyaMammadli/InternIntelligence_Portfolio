using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Auth;

public class RefreshTokenNotFoundException:BaseException
{
    public RefreshTokenNotFoundException() { }
    public RefreshTokenNotFoundException(string message) : base(message) { }
    public RefreshTokenNotFoundException(int StatusCode, string message) : base(StatusCode, message) { }
}
