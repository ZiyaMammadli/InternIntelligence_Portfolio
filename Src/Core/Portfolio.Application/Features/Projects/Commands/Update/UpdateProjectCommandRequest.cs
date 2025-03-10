﻿using MediatR;

namespace Portfolio.Application.Features.Projects.Commands.Update;

public class UpdateProjectCommandRequest:IRequest<Unit>
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
}
