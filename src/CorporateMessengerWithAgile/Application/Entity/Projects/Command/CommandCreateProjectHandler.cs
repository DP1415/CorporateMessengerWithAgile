using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Projects.Command
{
    public class CommandCreateProjectHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateProject, Project, ProjectDto>(context, mapper)
    {
        public override Result<Project> Create(CommandCreateProject request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Exception;

            var project = new Project
            {
                Title = title,
                CompanyId = request.CompanyId
            };

            return project;
        }
    }
}
