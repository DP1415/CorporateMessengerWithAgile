using Application.AbsQuery;
using Domain.Entity;
using Domain.Result;

namespace Application.Entity.Companies.Queries.GetById
{
    public record class CompanyGetByIdQuery
        (
            Guid Id
        )
        : AbsQueryEntity<Company, Result<CompanyGetByIdDto>>;
}
