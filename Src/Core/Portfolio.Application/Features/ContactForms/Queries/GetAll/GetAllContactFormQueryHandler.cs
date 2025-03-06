using MediatR;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Features.ContactForms.Queries.GetAll;

public class GetAllContactFormQueryHandler : IRequestHandler<GetAllContactFormQueryRequest, List<GetAllContactFormQueryRepsonse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllContactFormQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetAllContactFormQueryRepsonse>> Handle(GetAllContactFormQueryRequest request, CancellationToken cancellationToken)
    {
        List<ContactForm> contactForms = await _unitOfWork.GetReadRepository<ContactForm>().GetAllAsync();
        List<GetAllContactFormQueryRepsonse> getAllContactFormQueryRepsonses= contactForms.Select(cf => new GetAllContactFormQueryRepsonse()
        {
            Id = cf.Id,
            UserId = cf.UserId,
            Name = cf.Name,
            Message = cf.Message,
            Email = cf.Email,
            IsDeleted = cf.IsDeleted,
            CreateDated = cf.CreateDated,
            UpdateDated = cf.UpdateDated,
        }).ToList();
        return getAllContactFormQueryRepsonses;
    }
}
