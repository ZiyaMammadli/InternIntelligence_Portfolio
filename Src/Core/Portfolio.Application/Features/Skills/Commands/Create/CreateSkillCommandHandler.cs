using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Features.Skills.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.Skills.Commands.Create
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateRules _createRules;
        private readonly UserManager<AppUser> _userManager;

        public CreateSkillCommandHandler(IUnitOfWork unitOfWork,CreateRules createRules,UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _createRules = createRules;
            _userManager = userManager;
        }
        public async Task<Unit> Handle(CreateSkillCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByIdAsync(request.UserId.ToString());
            await _createRules.EnsureUserIdCheckAsync(user);
            await _createRules.EnsureSkillNameCheckAsync(request.Name);
            Skill skill = new()
            {
                UserId = user.Id,
                Name = request.Name,
                IsDeleted=false,
                CreateDated=DateTime.UtcNow,
                UpdateDated=DateTime.UtcNow,
            };
            await _unitOfWork.GetWriteRepository<Skill>().AddAsync(skill);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
