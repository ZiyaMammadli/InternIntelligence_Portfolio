using Portfolio.Application.Exceptions.Base;

namespace Portfolio.Application.Exceptions.Achievement;

public class AchievementAlreadyExistException:BaseException
{
    public AchievementAlreadyExistException() { }
    public AchievementAlreadyExistException(string message) : base(message) { }
    public AchievementAlreadyExistException(int StatusCode, string message) : base(StatusCode, message) { }
}
