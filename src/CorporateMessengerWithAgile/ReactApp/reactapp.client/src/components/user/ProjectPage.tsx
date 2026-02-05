// src/components/user/ProjectPage.tsx
import React from 'react';
import { useParams, useOutletContext, Link } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { TeamSummaryDto } from '../../models';
import type { EmployeeWithRelations, ProjectWithTeams } from '../../controllers';

const ProjectPage: React.FC = () => {
    const { companyTitle, projectTitle } = useParams<{ companyTitle: string; projectTitle: string }>();
    const { employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const decodedCompanyTitle = decodeURIComponent(companyTitle || '');
    const employeeWithRelations: EmployeeWithRelations | undefined = employeesWithRelations.find(emp => emp.company.title === decodedCompanyTitle);

    if (!employeeWithRelations) { return <div>Компания не найдена</div>; }

    const decodedProjectTitle = decodeURIComponent(projectTitle || '');
    const projectAndTeams: ProjectWithTeams | undefined = employeeWithRelations.projectsAndTeams?.find(p => p.project.title === decodedProjectTitle);

    if (!projectAndTeams) { return <div>Проект не найден</div>; }

    const getTeamRoute = (team: TeamSummaryDto): string => `/company/${companyTitle}/project/${encodeURIComponent(projectAndTeams.project.title)}/team/${encodeURIComponent(team.title)}`;

    return (<>
        <h1>Проект: {projectAndTeams.project.title}</h1>
        <p>Компания: {employeeWithRelations.company.title}</p>

        <h2>Команды проекта</h2>
        {projectAndTeams.teams.length > 0 ? (
            <ul>
                {projectAndTeams.teams.map(team => (
                    <li key={team.id}>
                        <Link to={getTeamRoute(team)}>
                            {team.title}
                        </Link>
                    </li>
                ))}
            </ul>
        ) : (
            <p>Нет команд</p>
        )}
    </>);
};

export default ProjectPage;
