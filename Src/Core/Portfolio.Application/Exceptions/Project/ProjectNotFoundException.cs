using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Project;

public class ProjectNotFoundException:BaseException
{
    public ProjectNotFoundException() { }
    public ProjectNotFoundException(string message) : base(message) { }
    public ProjectNotFoundException(int StatusCode, string message) : base(StatusCode, message) { }
}
