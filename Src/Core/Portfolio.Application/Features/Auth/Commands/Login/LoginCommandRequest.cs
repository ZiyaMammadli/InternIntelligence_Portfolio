﻿using MediatR;

namespace Portfolio.Application.Features.Auth.Commands.Login;

public class LoginCommandRequest:IRequest<LoginCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
