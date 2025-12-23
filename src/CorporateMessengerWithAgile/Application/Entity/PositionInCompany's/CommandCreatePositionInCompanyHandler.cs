using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.PositionInCompany_s
{
    public class CommandCreatePositionInCompanyHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreatePositionInCompany, PositionInCompany, PositionInCompanyDto>(context, mapper)
    {
        public override Result<PositionInCompany> Create(CommandCreatePositionInCompany request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Exception;

            var description = Text.Create(request.Description);
            if (description.IsFailure) return description.Exception;

            var position = new PositionInCompany
            {
                Title = title,
                Description = description,
                CompanyId = request.CompanyId
            };

            return position;
        }
    }
}
