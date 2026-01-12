using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetAll
{
    public class TaskItemsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<TaskItemsGetAllQuery, TaskItem, TaskItemDto>(context, mapper);
}
