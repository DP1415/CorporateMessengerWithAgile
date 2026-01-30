using Application.AbsCommand.Update;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Projects.Command.ProjectUpdate
{
    public class CommandUpdateProjectHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateProject, Project, ProjectSummaryDto>(context, mapper)
    {
        protected override Result<Project> Update(Project entity, CommandUpdateProject request)
        {
            if (request.Title is not null)
            {
                var title = Title.Create(request.Title);
                if (title.IsFailure) return title.Error;
                entity.Title = title;
            }

            if (request.CompanyId.HasValue)
            {
                entity.CompanyId = request.CompanyId.Value;
            }

            return entity;
        }
    }
}
