using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Features.Achievements.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entitiesl;

namespace Portfolio.Application.Features.Achievements.Commands.Create
{
    public class CreateAchievementCommandHandler : IRequestHandler<CreateAchievementCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly CreateRules _createRules;

        public CreateAchievementCommandHandler(IUnitOfWork unitOfWork,UserManager<AppUser> userManager,CreateRules createRules)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _createRules = createRules;
        }
        public async Task<Unit> Handle(CreateAchievementCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByIdAsync(request.UserId.ToString());
            await _createRules.EnsureUserIdCheckAsync(user);
            await _createRules.EnsureProjectNameCheckAsync(request.Name);
            Achievement achievement = new()
            {
                UserId = user.Id,
                Name = request.Name,
                Description = request.Description,
                AchievementDate = request.AchievementDate,
                IsDeleted=false,
                CreateDated=DateTime.UtcNow,
                UpdateDated=DateTime.UtcNow,
            };
            await _unitOfWork.GetWriteRepository<Achievement>().AddAsync(achievement);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
