using Application.Dto;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.ValueObjects;
using System.Linq.Expressions;

namespace Application
{
    file static class AutoMapperExtensions
    {
        internal static IMappingExpression<TEntity, TDto> MapProperty<TEntity, TDto, TValue>
            (
                this IMappingExpression<TEntity, TDto> map,
                Expression<Func<TDto, TValue>> destinationMember,
                Expression<Func<TEntity, TValue>> sourceMember
            )
            where TEntity : BaseEntity
            where TDto : BaseDto => map.ForMember(destinationMember, opt => opt.MapFrom(sourceMember));

        internal static IMappingExpression<TEntity, TDto> MapProperty<TEntity, TDto, TValue, TValueObject>
            (
                this IMappingExpression<TEntity, TDto> map,
                Expression<Func<TDto, TValue>> destinationMember,
                Expression<Func<TEntity, TValueObject>> sourceMember
            )
            where TEntity : BaseEntity
            where TDto : BaseDto
            where TValueObject : BaseValueObject<TValue>
        {
            var param = Expression.Parameter(typeof(TEntity), "entity");

            return map.ForMember(
                destinationMember,
                opt => opt.MapFrom(Expression.Lambda<Func<TEntity, TValue>>
                (
                    Expression.Property
                    (
                        Expression.Invoke(sourceMember, param),
                        nameof(BaseValueObject<TValue>.Value)
                    ),
                    param
                ))
            );
        }

        internal static IMappingExpression<TEntity, TDto> MapId<TEntity, TDto>(this IMappingExpression<TEntity, TDto> map)
            where TEntity : BaseEntity
            where TDto : BaseDto => map.MapProperty(dto => dto.Id, entity => entity.Id);

        internal static IMappingExpression<TEntity, TDto> MapChats<TEntity, TDto>(this IMappingExpression<TEntity, TDto> map)
            where TEntity : BaseEntityWithChats
            where TDto : BaseEntityWithChatsDto => map.MapProperty(dto => dto.ChatIds, entity => entity.Chats.Select(chat => chat.Id).ToList());
    }
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            // User
            CreateMap<User, UserSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.Email, user => user.Email)
                .MapProperty(dto => dto.Username, user => user.Username)
                .MapProperty(dto => dto.PhoneNumber, user => user.PhoneNumber)
                .MapProperty(dto => dto.Role, user => user.Role)
                .MapProperty(dto => dto.EmployeeIds, user => user.Employees.Select(employee => employee.Id).ToList());

            // Company
            CreateMap<Company, CompanySummaryDto>()
                .MapId()
                .MapProperty(dto => dto.Title, company => company.Title)
                .MapProperty(dto => dto.EmployeeIds, company => company.Employees.Select(employee => employee.Id).ToList())
                .MapProperty(dto => dto.PositionIds, company => company.Positions.Select(position => position.Id).ToList())
                .MapProperty(dto => dto.ProjectIds, company => company.Projects.Select(project => project.Id).ToList());

            // Employee
            CreateMap<Employee, EmployeeSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.CompanyId, employee => employee.CompanyId)
                .MapProperty(dto => dto.PositionInCompanyId, employee => employee.PositionInCompanyId)
                .MapProperty(dto => dto.UserId, employee => employee.UserId)
                .MapProperty(dto => dto.TeamMemberIds, employee => employee.TeamMembers.Select(teamMember => teamMember.Id).ToList());

            // PositionInCompany
            CreateMap<PositionInCompany, PositionInCompanySummaryDto>()
                .MapId()
                .MapProperty(dto => dto.CompanyId, position => position.CompanyId)
                .MapProperty(dto => dto.Title, position => position.Title)
                .MapProperty(dto => dto.Description, position => position.Description)
                .MapProperty(dto => dto.EmployeeIds, position => position.Employees.Select(employee => employee.Id).ToList());

            // Project
            CreateMap<Project, ProjectSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.CompanyId, project => project.CompanyId)
                .MapProperty(dto => dto.Title, project => project.Title)
                .MapProperty(dto => dto.TaskItemIds, project => project.TaskItems.Select(taskItem => taskItem.Id).ToList())
                .MapProperty(dto => dto.TeamIds, project => project.Teams.Select(team => team.Id).ToList());

            // Sprint
            CreateMap<Sprint, SprintSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.TeamId, sprint => sprint.TeamId)
                .MapProperty(dto => dto.DateStart, sprint => sprint.DateStart)
                .MapProperty(dto => dto.DateEnd, sprint => sprint.DateEnd)
                .MapProperty(dto => dto.TaskItemIds, sprint => sprint.TaskItems.Select(taskItem => taskItem.Id).ToList());

            // TaskItem
            CreateMap<TaskItem, TaskItemSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.ProjectId, taskItem => taskItem.ProjectId)
                .MapProperty(dto => dto.AuthorId, taskItem => taskItem.AuthorId)
                .MapProperty(dto => dto.ResponsibleId, taskItem => taskItem.ResponsibleId)
                .MapProperty(dto => dto.SprintWithLastMentionId, taskItem => taskItem.SprintWithLastMentionId)
                .MapProperty(dto => dto.ParentTaskId, taskItem => taskItem.ParentTaskId)
                .MapProperty(dto => dto.SubtaskIds, taskItem => taskItem.Subtasks.Select(task => task.Id).ToList())
                .MapProperty(dto => dto.Title, taskItem => taskItem.Title)
                .MapProperty(dto => dto.Description, taskItem => taskItem.Description)
                .MapProperty(dto => dto.Priority, taskItem => taskItem.Priority)
                .MapProperty(dto => dto.Complexity, taskItem => taskItem.Complexity)
                .MapProperty(dto => dto.Deadline, taskItem => taskItem.Deadline);

            // из TaskItemInSprint в TaskItemWithStatusDto
            CreateMap<TaskItemInSprint, TaskItemWithStatusDto>()
                .MapId()
                .MapProperty(dto => dto.ProjectId, taskItemInSprint => taskItemInSprint.TaskItem.ProjectId)
                .MapProperty(dto => dto.AuthorId, taskItemInSprint => taskItemInSprint.TaskItem.AuthorId)
                .MapProperty(dto => dto.ResponsibleId, taskItemInSprint => taskItemInSprint.TaskItem.ResponsibleId)
                .MapProperty(dto => dto.SprintWithLastMentionId, taskItemInSprint => taskItemInSprint.TaskItem.SprintWithLastMentionId)
                .MapProperty(dto => dto.ParentTaskId, taskItemInSprint => taskItemInSprint.TaskItem.ParentTaskId)
                .MapProperty(dto => dto.SubtaskIds, taskItemInSprint => taskItemInSprint.TaskItem.Subtasks.Select(task => task.Id).ToList())
                .MapProperty(dto => dto.Title, taskItemInSprint => taskItemInSprint.TaskItem.Title)
                .MapProperty(dto => dto.Description, taskItemInSprint => taskItemInSprint.TaskItem.Description)
                .MapProperty(dto => dto.Priority, taskItemInSprint => taskItemInSprint.TaskItem.Priority)
                .MapProperty(dto => dto.Complexity, taskItemInSprint => taskItemInSprint.TaskItem.Complexity)
                .MapProperty(dto => dto.Deadline, taskItemInSprint => taskItemInSprint.TaskItem.Deadline)
                .MapProperty(dto => dto.TaskStatus, taskItemInSprint => taskItemInSprint.TaskStatus);

            // TaskItemInSprint
            CreateMap<TaskItemInSprint, TaskItemInSprintSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.TaskItemId, taskItemInSprint => taskItemInSprint.TaskItemId)
                .MapProperty(dto => dto.SprintId, taskItemInSprint => taskItemInSprint.SprintId)
                .MapProperty(dto => dto.TaskStatus, taskItemInSprint => taskItemInSprint.TaskStatus);

            // Team
            CreateMap<Team, TeamSummaryDto>()
                .MapId().MapChats()
                .MapProperty(dto => dto.ProjectId, team => team.ProjectId)
                .MapProperty(dto => dto.Title, team => team.Title)
                .MapProperty(dto => dto.StandardSprintDuration, team => team.StandardSprintDuration)
                .MapProperty(dto => dto.TeamMemberIds, team => team.TeamMembers.Select(teamMember => teamMember.Id).ToList())
                .MapProperty(dto => dto.SprintIds, team => team.Sprints.Select(sprint => sprint.Id).ToList())
                .MapProperty(dto => dto.KanbanBoardColumnIds, team => team.KanbanBoardColumns.Select(kanbanBoardColumns => kanbanBoardColumns.Id).ToList());

            // TeamMember
            CreateMap<TeamMember, TeamMemberSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.EmployeeId, teamMember => teamMember.EmployeeId)
                .MapProperty(dto => dto.TeamId, teamMember => teamMember.TeamId);

            // KanbanBoardColumn
            CreateMap<KanbanBoardColumn, KanbanBoardColumnSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.TeamId, kanbanBoardColumn => kanbanBoardColumn.TeamId)
                .MapProperty(dto => dto.TaskStatus, kanbanBoardColumn => kanbanBoardColumn.TaskStatus)
                .MapProperty(dto => dto.PositionOnBoard, kanbanBoardColumn => kanbanBoardColumn.PositionOnBoard)
                .MapProperty(dto => dto.Title, kanbanBoardColumn => kanbanBoardColumn.Title);

            // Chat
            CreateMap<Chat, ChatSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.Name, chat => chat.Name)
                .MapProperty(dto => dto.Description, chat => chat.Description)
                .MapProperty(dto => dto.OwnerEmployeeId, chat => chat.OwnerEmployeeId)
                .MapProperty(dto => dto.OwnerTeamId, chat => chat.OwnerTeamId);

            // ChatMember
            CreateMap<ChatMember, ChatMemberSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.ChatId, chatMember => chatMember.ChatId)
                .MapProperty(dto => dto.UserId, chatMember => chatMember.UserId)
                .MapProperty(dto => dto.IsAdmin, chatMember => chatMember.IsAdmin);

            // Message
            CreateMap<Message, MessageSummaryDto>()
                .MapId()
                .MapProperty(dto => dto.Content, message => message.Content)
                .MapProperty(dto => dto.ChatId, message => message.ChatId)
                .MapProperty(dto => dto.SenderId, message => message.SenderId)
                .MapProperty(dto => dto.IsEdited, message => message.IsEdited);
        }
    }
}
