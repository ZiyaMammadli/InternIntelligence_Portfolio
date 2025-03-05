using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Achievement;

public class AchievementNotFoundException:BaseException
{
    public AchievementNotFoundException() { }
    public AchievementNotFoundException(string message) : base(message) { }
    public AchievementNotFoundException(int StatusCode, string message) : base(StatusCode, message) { }
}
