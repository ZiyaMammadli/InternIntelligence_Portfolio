using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Skill;

public class SkillAlreadyExistException:BaseException
{
    public SkillAlreadyExistException() { }
    public SkillAlreadyExistException(string message) : base(message) { }
    public SkillAlreadyExistException(int StatusCode, string message) : base(StatusCode, message) { }
}
