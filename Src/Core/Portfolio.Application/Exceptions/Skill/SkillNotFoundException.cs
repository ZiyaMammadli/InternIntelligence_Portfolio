using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Skill;

public class SkillNotFoundException:BaseException
{
    public SkillNotFoundException() { }
    public SkillNotFoundException(string message) : base(message) { }
    public SkillNotFoundException(int StatusCode, string message) : base(StatusCode, message) { }
}
