using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItemInSprint_s
{
    public class TaskItemsInSprintGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TaskItemsInSprintGetAllQuery, TaskItemInSprint, TaskItemInSprintDto>(context, mapper);
}
