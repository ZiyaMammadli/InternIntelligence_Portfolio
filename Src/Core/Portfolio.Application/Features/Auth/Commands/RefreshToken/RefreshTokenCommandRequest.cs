using MediatR;

namespace Portfolio.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandRequest:IRequest<RefreshTokenCommandResponse>
{
    public string RefreshToken { get; set; }
    public string AccessToken { get; set; }
}
