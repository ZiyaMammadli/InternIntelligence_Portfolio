using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Features.ContactForms.Rules;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.ContactForms.Commands.SubmitForm;

public class SubmitFormCommandHandler : IRequestHandler<SubmitFormCommandRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly SubmitFormRules _submitFormRules;
    private readonly UserManager<AppUser> _userManager;

    public SubmitFormCommandHandler(IUnitOfWork unitOfWork,SubmitFormRules submitFormRules,UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _submitFormRules = submitFormRules;
        _userManager = userManager;
    }
    public async Task<Unit> Handle(SubmitFormCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? user=await _userManager.FindByIdAsync(request.UserId.ToString());
        await _submitFormRules.EnsureUserIdCheckAsync(user);
        ContactForm contactForm = new()
        {
            UserId = user.Id,
            Name = request.Name,
            Message = request.Message,
            Email = request.Email,
            IsDeleted=false,
            CreateDated=DateTime.UtcNow,
            UpdateDated=DateTime.UtcNow,
        };
        await _unitOfWork.GetWriteRepository<ContactForm>().AddAsync(contactForm);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
