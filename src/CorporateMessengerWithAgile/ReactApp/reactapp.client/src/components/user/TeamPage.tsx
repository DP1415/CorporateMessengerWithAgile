// src/components/user/TeamPage.tsx
import React from 'react';
import { useParams, useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { TeamSummaryDto } from '../../models';
import type { EmployeeWithRelations, ProjectWithTeams } from '../../controllers';

const TeamPage: React.FC = () => {
    const { companyTitle, projectTitle, teamTitle } = useParams<{ companyTitle: string; projectTitle: string; teamTitle: string; }>();
    const { employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const decodedCompanyTitle = decodeURIComponent(companyTitle || '');
    const employeeWithRelations: EmployeeWithRelations | undefined = employeesWithRelations.find(emp => emp.company.title === decodedCompanyTitle);

    if (!employeeWithRelations) { return <div>Компания не найдена</div>; }

    const decodedProjectTitle = decodeURIComponent(projectTitle || '');
    const projectAndTeams: ProjectWithTeams | undefined = employeeWithRelations.projectsAndTeams?.find(p => p.project.title === decodedProjectTitle);

    if (!projectAndTeams) { return <div>Проект не найден</div>; }

    const decodedTeamTitle = decodeURIComponent(teamTitle || '');
    const team: TeamSummaryDto | undefined = projectAndTeams.teams.find(t => t.title === decodedTeamTitle);

    if (!team) { return <div>Команда не найдена</div>; }

    return (
        <>
            <h1>Команда: {team.title}</h1>
            <p>Компания: {employeeWithRelations.company.title}</p>
            <p>Проект: {projectAndTeams.project.title}</p>
        </>
    );
};

export default TeamPage;
