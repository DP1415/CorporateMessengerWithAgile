using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItems
{
    public class TaskItemsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<TaskItemsGetAllQuery, TaskItem, TaskItemDto>(context, mapper);
}
