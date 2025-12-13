using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.KanbanBoardColumns
{
    public class KanbanBoardColumnsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<KanbanBoardColumnsGetAllQuery, KanbanBoardColumn, KanbanBoardColumnDto>(context, mapper);
}
