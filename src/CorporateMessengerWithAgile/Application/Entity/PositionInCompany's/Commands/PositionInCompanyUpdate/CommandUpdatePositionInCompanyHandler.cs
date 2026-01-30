using Application.AbsCommand.Update;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.PositionInCompany_s
{
    public class CommandUpdatePositionInCompanyHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdatePositionInCompany, PositionInCompany, PositionInCompanySummaryDto>(context, mapper)
    {
        protected override Result<PositionInCompany> Update(PositionInCompany entity, CommandUpdatePositionInCompany request)
        {
            if (request.Title is not null)
            {
                var title = Title.Create(request.Title);
                if (title.IsFailure) return title.Error;
                entity.Title = title;
            }

            if (request.Description is not null)
            {
                var description = Text.Create(request.Description);
                if (description.IsFailure) return description.Error;
                entity.Description = description;
            }

            if (request.CompanyId.HasValue)
            {
                entity.CompanyId = request.CompanyId.Value;
            }

            return entity;
        }
    }
}
