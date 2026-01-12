using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.KanbanBoardColumns.Queries.KanbanBoardColumnsGetAll
{
    public class KanbanBoardColumnsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryGetAllEntityHandler<KanbanBoardColumnsGetAllQuery, KanbanBoardColumn, KanbanBoardColumnDto>(context, mapper);
}
