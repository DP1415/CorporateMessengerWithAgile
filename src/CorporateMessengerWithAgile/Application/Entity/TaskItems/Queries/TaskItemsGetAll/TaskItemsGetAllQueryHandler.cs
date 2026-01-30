using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetAll
{
    public class TaskItemsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<TaskItemsGetAllQuery, TaskItem, TaskItemSummaryDto>(context, mapper);
}
