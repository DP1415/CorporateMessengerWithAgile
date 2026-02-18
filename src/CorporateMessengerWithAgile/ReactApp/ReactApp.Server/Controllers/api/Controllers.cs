using Application.Dto.Summary;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class CompanyController(ISender sender) : ApiControllerBase
    <
        Company,
        CompanySummaryDto,
        Application.Entity.Companies.Queries.GetAll.CompaniesGetAllQuery,
        Application.Entity.Companies.Command.CompanyCreate.CommandCreateCompany,
        Application.Entity.Companies.Command.CompanyUpdate.CommandUpdateCompany,
        Application.Entity.Companies.Command.CompanyDelete.CommandDeleteCompany
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class EmployeeController(ISender sender) : ApiControllerBase
    <
        Employee,
        EmployeeSummaryDto,
        Application.Entity.Employees.Queries.EmployeesGetAll.EmployeesGetAllQuery,
        Application.Entity.Employees.Commands.EmployeeCreate.CommandCreateEmployee,
        Application.Entity.Employees.Commands.EmployeeUpdate.CommandUpdateEmployee,
        Application.Entity.Employees.Commands.EmployeeDelete.CommandDeleteEmployee
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class KanbanBoardColumnController(ISender sender) : ApiControllerBase
    <
        KanbanBoardColumn,
        KanbanBoardColumnSummaryDto,
        Application.Entity.KanbanBoardColumns.Queries.KanbanBoardColumnsGetAll.KanbanBoardColumnsGetAllQuery,
        Application.Entity.KanbanBoardColumns.Commands.KanbanBoardColumnCreate.CommandCreateKanbanBoardColumn,
        Application.Entity.KanbanBoardColumns.Commands.KanbanBoardColumnUpdate.CommandUpdateKanbanBoardColumn,
        Application.Entity.KanbanBoardColumns.Commands.KanbanBoardColumnDelete.CommandDeleteKanbanBoardColumn
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class PositionInCompanyController(ISender sender) : ApiControllerBase
    <
        PositionInCompany,
        PositionInCompanySummaryDto,
        Application.Entity.PositionInCompany_s.Queries.PositionInCompaniesGetAll.PositionInCompaniesGetAllQuery,
        Application.Entity.PositionInCompany_s.Commands.PositionInCompanyCreate.CommandCreatePositionInCompany,
        Application.Entity.PositionInCompany_s.Commands.PositionInCompanyUpdate.CommandUpdatePositionInCompany,
        Application.Entity.PositionInCompany_s.Commands.PositionInCompanyDelete.CommandDeletePositionInCompany
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class ProjectController(ISender sender) : ApiControllerBase
    <
        Project,
        ProjectSummaryDto,
        Application.Entity.Projects.Queries.GetAll.ProjectsGetAllQuery,
        Application.Entity.Projects.Command.ProjectCreate.CommandCreateProject,
        Application.Entity.Projects.Command.ProjectUpdate.CommandUpdateProject,
        Application.Entity.Projects.Command.ProjectDelete.CommandDeleteProject
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class SprintController(ISender sender) : ApiControllerBase
    <
        Sprint,
        SprintSummaryDto,
        Application.Entity.Sprints.Queries.SprintsGetAll.SprintsGetAllQuery,
        Application.Entity.Sprints.Commands.SprintCreate.CommandCreateSprint,
        Application.Entity.Sprints.Commands.SprintUpdate.CommandUpdateSprint,
        Application.Entity.Sprints.Commands.SprintDelete.CommandDeleteSprint
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class TaskItemController(ISender sender) : ApiControllerBase
    <
        TaskItem,
        TaskItemSummaryDto,
        Application.Entity.TaskItems.Queries.TaskItemsGetAll.TaskItemsGetAllQuery,
        Application.Entity.TaskItems.Commands.TaskItemCreate.CommandCreateTaskItem,
        Application.Entity.TaskItems.Commands.TaskItemUpdate.CommandUpdateTaskItem,
        Application.Entity.TaskItems.Commands.TaskItemDelete.CommandDeleteTaskItem
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class TaskItemInSprintController(ISender sender) : ApiControllerBase
    <
        TaskItemInSprint,
        TaskItemInSprintSummaryDto,
        Application.Entity.TaskItemInSprints.Queries.TaskItemsInSprintGetAll.TaskItemsInSprintGetAllQuery,
        Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintCreate.CommandCreateTaskItemInSprint,
        Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintUpdate.CommandUpdateTaskItemInSprint,
        Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintDelete.CommandDeleteTaskItemInSprint
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class TeamController(ISender sender) : ApiControllerBase
    <
        Team,
        TeamSummaryDto,
        Application.Entity.Teams.Queries.TeamsGetAll.TeamsGetAllQuery,
        Application.Entity.Teams.Commands.TeamCreate.CommandCreateTeam,
        Application.Entity.Teams.Commands.TeamUpdate.CommandUpdateTeam,
        Application.Entity.Teams.Commands.TeamDelete.CommandDeleteTeam
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class TeamMemberController(ISender sender) : ApiControllerBase
    <
        TeamMember,
        TeamMemberSummaryDto,
        Application.Entity.TeamMembers.Queries.TeamMembersGetAll.TeamMembersGetAllQuery,
        Application.Entity.TeamMembers.Commands.TeamMemberCreate.CommandCreateTeamMember,
        Application.Entity.TeamMembers.Commands.TeamMemberUpdate.CommandUpdateTeamMember,
        Application.Entity.TeamMembers.Commands.TeamMemberDelete.CommandDeleteTeamMember
    >(sender, id => new(id));

    [Tags(ApiControllerBaseTag)]
    public class UserController(ISender sender) : ApiControllerBase
    <
        User,
        UserSummaryDto,
        Application.Entity.Users.Queries.UsersGetAll.UsersGetAllQuery,
        Application.Entity.Users.Commands.UserCreate.CommandCreateUser,
        Application.Entity.Users.Commands.UserChange.CommandUpdateUser,
        Application.Entity.Users.Commands.UserDelete.CommandDeleteUser
    >(sender, id => new(id));
}