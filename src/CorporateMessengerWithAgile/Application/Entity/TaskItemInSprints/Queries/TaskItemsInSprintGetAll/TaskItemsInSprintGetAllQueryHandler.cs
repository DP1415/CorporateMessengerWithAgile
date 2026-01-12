using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItemInSprints.Queries.TaskItemsInSprintGetAll
{
    public class TaskItemsInSprintGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryGetAllEntityHandler<TaskItemsInSprintGetAllQuery, TaskItemInSprint, TaskItemInSprintDto>(context, mapper);
}
