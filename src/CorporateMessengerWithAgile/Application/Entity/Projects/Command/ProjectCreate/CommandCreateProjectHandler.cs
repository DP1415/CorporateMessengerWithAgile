using Application.AbsCommand.Create;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Projects.Command.ProjectCreate
{
    public class CommandCreateProjectHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateProject, Project, ProjectSummaryDto>(context, mapper)
    {
        public override Result<Project> Create(CommandCreateProject request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Error;

            var project = new Project
            {
                Title = title,
                CompanyId = request.CompanyId
            };

            return project;
        }
    }
}
