using Application.Command;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Companies
{
    public class CommandUpdateCompanyHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateCompany, Company, CompanyDto>(context, mapper)
    {
        protected override Result<Company> Update(Company entity, CommandUpdateCompany request)
        {
            if (request.Title is not null)
            {
                var title = Title.Create(request.Title);
                if (title.IsFailure) return title.Exception;
                entity.Title = title;
            }

            return entity;
        }
    }
}
