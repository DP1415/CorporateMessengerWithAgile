using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<UsersGetAllQuery, User, UserDto>(context, mapper);
}
