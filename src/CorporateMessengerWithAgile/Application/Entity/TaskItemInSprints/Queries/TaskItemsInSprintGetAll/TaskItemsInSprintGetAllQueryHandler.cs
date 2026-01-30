using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.TaskItemInSprints.Queries.TaskItemsInSprintGetAll
{
    public class TaskItemsInSprintGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<TaskItemsInSprintGetAllQuery, TaskItemInSprint, TaskItemInSprintSummaryDto>(context, mapper);
}
