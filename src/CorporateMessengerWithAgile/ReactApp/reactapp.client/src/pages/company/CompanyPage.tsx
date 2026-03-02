// src/pages/company/CompanyPage.tsx
import React from 'react';
import { Link, useParams, useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../../layouts';
import { type EmployeeWithRelations } from '../../controllers';
import { GetProjectRoute, GetTeamRoute } from '../../utils/routeHelpers';

const CompanyPage: React.FC = () => {
    const { companyTitle } = useParams<{ companyTitle: string }>();
    const { employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const decodedTitle = decodeURIComponent(companyTitle || '');
    const employeeWithRelations: EmployeeWithRelations | undefined = employeesWithRelations.find(emp => emp.company.title === decodedTitle);

    if (!employeeWithRelations || companyTitle == undefined) { return <div>Компания не найдена</div>; }

    const projectsAndTeams = employeeWithRelations.projectsAndTeams;

    return (<>
        <h2>Информация о компании</h2>
        <p>{employeeWithRelations.company.title}</p>
        <p>ID: {employeeWithRelations.company.id}</p>
        <hr />

        <h2>Должность в компании</h2>
        <p>{employeeWithRelations.positionInCompany.title}</p>
        <p>{employeeWithRelations.positionInCompany.id}</p>
        <p>{employeeWithRelations.positionInCompany.description}</p>
        <hr />

        <h2>Проекты и команды</h2>
        {
            !projectsAndTeams || projectsAndTeams.length === 0
                ? <p>Нет проектов</p>
                : projectsAndTeams.map((projectAndTeams) =>
                    <div key={projectAndTeams.project.id}>
                        <Link to={GetProjectRoute(companyTitle, projectAndTeams.project.title)}>
                            <h3>{projectAndTeams.project.title}</h3>
                        </Link>
                        <ul>
                            {
                                projectAndTeams.teams.length === 0
                                    ? <li>Нет команд в этом проекте</li>
                                    : projectAndTeams.teams.map((team) =>
                                        <li key={team.id}>
                                            <Link to={GetTeamRoute(companyTitle, projectAndTeams.project.title, team.title)}>
                                                {team.title}
                                            </Link>
                                        </li>
                                    )
                            }
                        </ul>
                    </div>
                )

        }
    </>);
};

export default CompanyPage;
