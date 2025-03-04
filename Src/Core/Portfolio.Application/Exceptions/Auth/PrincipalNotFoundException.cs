using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Auth;

public class PrincipalNotFoundException:BaseException
{
    public PrincipalNotFoundException() { }
    public PrincipalNotFoundException(string message) : base(message) { }
    public PrincipalNotFoundException(int StatusCode, string message) : base(StatusCode, message) { }
}
