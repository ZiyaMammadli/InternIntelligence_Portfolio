using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Project;

public class ProjectAlreadyExistException:BaseException
{
    public ProjectAlreadyExistException() { }
    public ProjectAlreadyExistException(string message) : base(message) { }
    public ProjectAlreadyExistException(int StatusCode, string message) : base(StatusCode, message) { }
}
