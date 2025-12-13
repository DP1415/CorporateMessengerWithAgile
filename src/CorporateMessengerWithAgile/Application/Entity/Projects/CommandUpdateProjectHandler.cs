using Application.Command;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Projects
{
    public class CommandUpdateProjectHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateProject, Project, ProjectDto>(context, mapper)
    {
        protected override Result<Project> Update(Project entity, CommandUpdateProject request)
        {
            if (request.Title is not null)
            {
                var title = Title.Create(request.Title);
                if (title.IsFailure) return title.Exception;
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
