using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<UsersGetAllQuery, User, UserDto>(context, mapper);
}
