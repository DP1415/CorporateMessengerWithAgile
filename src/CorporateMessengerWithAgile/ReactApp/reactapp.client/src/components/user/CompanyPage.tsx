// src/components/user/CompanyPage.tsx
import React from 'react';
import { Link, useParams, useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from './UserLayout';
import type { ProjectSummaryDto, TeamSummaryDto } from '../../models';
import { type EmployeeWithRelations } from '../../controllers';

const CompanyPage: React.FC = () => {
    const { companyTitle } = useParams<{ companyTitle: string }>();
    const { employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const decodedTitle = decodeURIComponent(companyTitle || '');
    const employeeWithRelations: EmployeeWithRelations | undefined = employeesWithRelations.find(emp => emp.company.title === decodedTitle);

    if (!employeeWithRelations) { return <div>Компания не найдена</div>; }

    const projectsAndTeams = employeeWithRelations.projectsAndTeams;

    const getProjectRoute = (project: ProjectSummaryDto): string =>
        `/company/${companyTitle}/project/${encodeURIComponent(project.title)}`
    const getTeamRoute = (project: ProjectSummaryDto, team: TeamSummaryDto): string =>
        `${getProjectRoute(project)}/team/${encodeURIComponent(team.title)}`

    return (<>
        <h1>{employeeWithRelations.company.title}</h1>

        <h2>Информация о компании</h2>
        <p>ID: {employeeWithRelations.company.id}</p>

        <h2>Должность в компании</h2>
        <p><strong>{employeeWithRelations.positionInCompany.title}</strong></p>
        <p>{employeeWithRelations.positionInCompany.description}</p>

        <h2>Проекты и команды</h2>
        {
            !projectsAndTeams || projectsAndTeams.length === 0
                ? (<p>Нет проектов</p>)
                : (
                    projectsAndTeams.map((projectAndTeams) => (
                        <div key={projectAndTeams.project.id}>
                            <Link to={getProjectRoute(projectAndTeams.project)}>
                                <h3>{projectAndTeams.project.title}</h3>
                            </Link>
                            {
                                projectAndTeams.teams.length === 0
                                    ? (<p>Нет команд в этом проекте</p>)
                                    : (
                                        <ul>
                                            {projectAndTeams.teams.map((team) => (
                                                <li key={team.id}>
                                                    <Link to={getTeamRoute(projectAndTeams.project, team)}>
                                                        {team.title}
                                                    </Link>
                                                </li>
                                            ))}
                                        </ul>
                                    )
                            }
                        </div >
                    ))
                )
        }
    </>);
};

export default CompanyPage;
