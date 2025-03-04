using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Auth;

public class RefreshTokenExpiredException:BaseException
{
    public RefreshTokenExpiredException() { }
    public RefreshTokenExpiredException(string message) : base(message) { }
    public RefreshTokenExpiredException(int StatusCode, string message) : base(StatusCode, message) { }
}
