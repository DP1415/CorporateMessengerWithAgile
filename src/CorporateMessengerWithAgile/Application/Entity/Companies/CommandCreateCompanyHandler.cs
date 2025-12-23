using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Companies
{
    public class CommandCreateCompanyHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateCompany, Company, CompanyDto>(context, mapper)
    {
        public override Result<Company> Create(CommandCreateCompany request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Exception;

            var company = new Company
            {
                Title = title
            };

            return company;
        }
    }
}
