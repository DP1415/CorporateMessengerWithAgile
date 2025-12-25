using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItemInSprint_s
{
    public class TaskItemsInSprintGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<TaskItemsInSprintGetAllQuery, TaskItemInSprint, TaskItemInSprintDto>(context, mapper);
}
