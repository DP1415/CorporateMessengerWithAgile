namespace Application
{
    public class EntityMappingProfile : AutoMapper.Profile
    {
        public EntityMappingProfile()
        {
            // User
            CreateMap<Domain.Entity.User, Dto.UserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email.Value))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Username.Value))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber.Value))
                .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role))
                .ForMember(d => d.EmployeeIds, opt => opt.MapFrom(s => s.Employees.Select(e => e.Id).ToList()));

            // Company
            CreateMap<Domain.Entity.Company, Dto.CompanyDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title.Value))
                .ForMember(d => d.EmployeeIds, opt => opt.MapFrom(s => s.Employees.Select(e => e.Id).ToList()))
                .ForMember(d => d.PositionIds, opt => opt.MapFrom(s => s.Positions.Select(p => p.Id).ToList()))
                .ForMember(d => d.ProjectIds, opt => opt.MapFrom(s => s.Projects.Select(p => p.Id).ToList()));

            // Employee
            CreateMap<Domain.Entity.Employee, Dto.EmployeeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                .ForMember(d => d.PositionInCompanyId, opt => opt.MapFrom(s => s.PositionInCompanyId))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.TeamMemberIds, opt => opt.MapFrom(s => s.TeamMembers.Select(tm => tm.Id).ToList()));

            CreateMap<Domain.Entity.Employee, Dto.WorkplaceDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Company))
                .ForMember(d => d.PositionInCompany, opt => opt.MapFrom(s => s.PositionInCompany))
                .ForMember(d => d.User, opt => opt.MapFrom(s => s.User))
                .ForMember(d => d.TeamMembers, opt => opt.MapFrom(s => s.TeamMembers.ToList()));

            // PositionInCompany
            CreateMap<Domain.Entity.PositionInCompany, Dto.PositionInCompanyDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title.Value))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Value))
                .ForMember(d => d.EmployeeIds, opt => opt.MapFrom(s => s.Employees.Select(e => e.Id).ToList()));

            // Project
            CreateMap<Domain.Entity.Project, Dto.ProjectDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title.Value))
                .ForMember(d => d.TaskItemIds, opt => opt.MapFrom(s => s.TaskItems.Select(t => t.Id).ToList()))
                .ForMember(d => d.TeamIds, opt => opt.MapFrom(s => s.Teams.Select(t => t.Id).ToList()));

            // Sprint
            CreateMap<Domain.Entity.Sprint, Dto.SprintDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.TeamId, opt => opt.MapFrom(s => s.TeamId))
                .ForMember(d => d.DateStart, opt => opt.MapFrom(s => s.DateStart))
                .ForMember(d => d.DateEnd, opt => opt.MapFrom(s => s.DateEnd))
                .ForMember(d => d.TaskItemIds, opt => opt.MapFrom(s => s.TaskItems.Select(t => t.Id).ToList()));

            // TaskItem
            CreateMap<Domain.Entity.TaskItem, Dto.TaskItemDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.ProjectId, opt => opt.MapFrom(s => s.ProjectId))
                .ForMember(d => d.AuthorId, opt => opt.MapFrom(s => s.AuthorId))
                .ForMember(d => d.ResponsibleId, opt => opt.MapFrom(s => s.ResponsibleId))
                .ForMember(d => d.SprintWithLastMentionId, opt => opt.MapFrom(s => s.SprintWithLastMentionId))
                .ForMember(d => d.ParentTaskId, opt => opt.MapFrom(s => s.ParentTaskId))
                .ForMember(d => d.SubtaskIds, opt => opt.MapFrom(s => s.Subtasks.Select(st => st.Id).ToList()))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title.Value))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Value))
                .ForMember(d => d.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(d => d.Complexity, opt => opt.MapFrom(s => s.Complexity))
                .ForMember(d => d.Deadline, opt => opt.MapFrom(s => s.Deadline));

            // TaskItemInSprint
            CreateMap<Domain.Entity.TaskItemInSprint, Dto.TaskItemInSprintDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.TaskItemId, opt => opt.MapFrom(s => s.TaskItemId))
                .ForMember(d => d.SprintId, opt => opt.MapFrom(s => s.SprintId))
                .ForMember(d => d.TaskStatus, opt => opt.MapFrom(s => s.TaskStatus))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description.Value));

            // Team
            CreateMap<Domain.Entity.Team, Dto.TeamDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.ProjectId, opt => opt.MapFrom(s => s.ProjectId))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title.Value))
                .ForMember(d => d.StandardSprintDuration, opt => opt.MapFrom(s => s.StandardSprintDuration))
                .ForMember(d => d.TeamMemberIds, opt => opt.MapFrom(s => s.TeamMembers.Select(tm => tm.Id).ToList()))
                .ForMember(d => d.SprintIds, opt => opt.MapFrom(s => s.Sprints.Select(sp => sp.Id).ToList()))
                .ForMember(d => d.KanbanBoardColumnIds, opt => opt.MapFrom(s => s.KanbanBoardColumns.Select(k => k.Id).ToList()));

            // TeamMember
            CreateMap<Domain.Entity.TeamMember, Dto.TeamMemberDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.EmployeeId, opt => opt.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.TeamId, opt => opt.MapFrom(s => s.TeamId));

            // KanbanBoardColumn
            CreateMap<Domain.Entity.KanbanBoardColumn, Dto.KanbanBoardColumnDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.TeamId, opt => opt.MapFrom(s => s.TeamId))
                .ForMember(d => d.TaskStatus, opt => opt.MapFrom(s => s.TaskStatus))
                .ForMember(d => d.PositionOnBoard, opt => opt.MapFrom(s => s.PositionOnBoard))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title.Value));
        }
    }
}
