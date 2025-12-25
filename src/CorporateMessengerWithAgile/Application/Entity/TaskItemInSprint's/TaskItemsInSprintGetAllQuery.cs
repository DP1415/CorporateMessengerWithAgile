using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprint_s
{
    public record TaskItemsInSprintGetAllQuery()
        : AbsQueryGetAllEntity<TaskItemInSprint, TaskItemInSprintDto>(
            [
                new Include<TaskItemInSprint, TaskItem>(t => t.TaskItem),
                new Include<TaskItemInSprint, Sprint>(t => t.Sprint)
            ]
        );
}
