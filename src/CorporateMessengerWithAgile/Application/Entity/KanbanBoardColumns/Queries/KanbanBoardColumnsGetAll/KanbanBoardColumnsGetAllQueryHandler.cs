using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.KanbanBoardColumns.Queries.KanbanBoardColumnsGetAll
{
    public class KanbanBoardColumnsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<KanbanBoardColumnsGetAllQuery, KanbanBoardColumn, KanbanBoardColumnSummaryDto>(context, mapper);
}
