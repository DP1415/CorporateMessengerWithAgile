using Application.AbsCommand.Create;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.PositionInCompany_s
{
    public class CommandCreatePositionInCompanyHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreatePositionInCompany, PositionInCompany, PositionInCompanySummaryDto>(context, mapper)
    {
        public override Result<PositionInCompany> Create(CommandCreatePositionInCompany request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Error;

            var description = Text.Create(request.Description);
            if (description.IsFailure) return description.Error;

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
