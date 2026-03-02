using Application.AbsQuery;
using Domain.Entity;
using Domain.Result;

namespace Application.Entity.Companies.Queries.GetById
{
    public record class CompanyGetByIdQuery
        (
            Guid Id
        )
        : AbsQuery<Company, Result<CompanyGetByIdDto>>;
}
