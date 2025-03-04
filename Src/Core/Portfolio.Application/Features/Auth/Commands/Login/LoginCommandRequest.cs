using MediatR;
using System.ComponentModel;

namespace Portfolio.Application.Features.Auth.Commands.Login;

public class LoginCommandRequest:IRequest<LoginCommandResponse>
{
    [DefaultValue("Emil_077@gmail.com")]
    public string Email { get; set; }
    [DefaultValue("Salam123@")]
    public string Password { get; set; }
}
