using Application.Dto;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.ValueObjects;
using System.Data;
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
            where TDto : BaseDto
            => map.ForMember(destinationMember, opt => opt.MapFrom(sourceMember));

        internal static IMappingExpression<TEntity, TDto> MapIds<TEntity, TDto, TEntityItem>
            (
                this IMappingExpression<TEntity, TDto> map,
                Expression<Func<TDto, IReadOnlyList<Guid>>> destinationMember,
                Func<TEntity, IEnumerable<TEntityItem>> sourceSelector
            )
            where TEntity : BaseEntity
            where TDto : BaseDto
            where TEntityItem : BaseEntity
            => map.MapProperty(destinationMember, src => sourceSelector(src).Select(item => item.Id).ToList());

        internal static IMappingExpression<TEntity, TDto> MapChats<TEntity, TDto>
            (
                this IMappingExpression<TEntity, TDto> map
            )
            where TEntity : BaseEntityWithChats
            where TDto : BaseEntityWithChatsDto
            => map.MapIds(dto => dto.ChatIds, entity => entity.Chats);
    }
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<BaseValueObject<string>, string>().ConvertUsing(s => s.Value);

            CreateMap<User, UserSummaryDto>()
                .MapIds(dto => dto.EmployeeIds, user => user.Employees);

            CreateMap<Company, CompanySummaryDto>()
                .MapIds(dto => dto.EmployeeIds, company => company.Employees)
                .MapIds(dto => dto.PositionIds, company => company.Positions)
                .MapIds(dto => dto.ProjectIds, company => company.Projects);

            CreateMap<Employee, EmployeeSummaryDto>()
                .MapIds(dto => dto.TeamMemberIds, employee => employee.TeamMembers);

            CreateMap<PositionInCompany, PositionInCompanySummaryDto>()
                .MapIds(dto => dto.EmployeeIds, position => position.Employees);

            CreateMap<Project, ProjectSummaryDto>()
                .MapIds(dto => dto.TaskItemIds, project => project.TaskItems)
                .MapIds(dto => dto.TeamIds, project => project.Teams);

            CreateMap<Sprint, SprintSummaryDto>()
                .MapIds(dto => dto.TaskItemIds, sprint => sprint.TaskItems);

            CreateMap<TaskItem, TaskItemSummaryDto>()
                .MapIds(dto => dto.SubtaskIds, taskItem => taskItem.Subtasks);

            CreateMap<TaskItemInSprint, TaskItemInSprintSummaryDto>();
            CreateMap<TaskItemInSprint, TaskItemWithStatusDto>()
                .MapIds(dto => dto.SubtaskIds, taskItemInSprint => taskItemInSprint.TaskItem.Subtasks);


            CreateMap<Team, TeamSummaryDto>()
                .MapChats()
                .MapIds(dto => dto.TeamMemberIds, team => team.TeamMembers)
                .MapIds(dto => dto.SprintIds, team => team.Sprints)
                .MapIds(dto => dto.KanbanBoardColumnIds, team => team.KanbanBoardColumns);

            CreateMap<TeamMember, TeamMemberSummaryDto>();
            CreateMap<KanbanBoardColumn, KanbanBoardColumnSummaryDto>();
            CreateMap<Chat, ChatSummaryDto>();
            CreateMap<ChatMember, ChatMemberSummaryDto>();
            CreateMap<Message, MessageSummaryDto>();
        }
    }
}
