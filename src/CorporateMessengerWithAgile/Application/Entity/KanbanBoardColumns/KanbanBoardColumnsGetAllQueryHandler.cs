using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.KanbanBoardColumns
{
    public class KanbanBoardColumnsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryGetAllEntityHandler<KanbanBoardColumnsGetAllQuery, KanbanBoardColumn, KanbanBoardColumnDto>(context, mapper);
}
