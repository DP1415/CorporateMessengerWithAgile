// src/components/user/CompanyPage.tsx
import React, { useState, useEffect } from 'react';
import { Link, useParams, useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { AppError, ProjectSummaryDto, Result, TeamSummaryDto } from '../../models';
import { UserController, type ProjectWithTeamsDto, type EmployeeWithRelationsDto } from '../../controllers';

export interface CompanyNavigationState {
    employeeWithRelations: EmployeeWithRelationsDto;
    projectAndTeams: ProjectWithTeamsDto;
    team: TeamSummaryDto | null;
    timestamp: number;
}

const CompanyPage: React.FC = () => {
    const { companyTitle } = useParams<{ companyTitle: string }>();
    const { employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const [projectsAndTeams, setProjectsAndTeams] = useState<ProjectWithTeamsDto[] | null>(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<AppError | null>(null);

    const decodedTitle = decodeURIComponent(companyTitle || '');
    const employeeWithRelations: EmployeeWithRelationsDto | undefined = decodedTitle && employeesWithRelations
        ? employeesWithRelations.find(emp => emp.company.title === decodedTitle)
        : undefined;

    useEffect(() => {
        if (!employeeWithRelations) {
            // eslint-disable-next-line react-hooks/set-state-in-effect
            setProjectsAndTeams(null);
            setError(null);
            return;
        }

        const fetchProjectsAndTeams = async () => {
            setLoading(true);
            setError(null);

            const controller = new UserController();
            const result: Result<ProjectWithTeamsDto[]> = await controller.getProjectsAndTeams(employeeWithRelations.id);
            if (result.isFailure) {
                setError(result.error);
                setProjectsAndTeams(null);
            } else {
                setError(null);
                setProjectsAndTeams(result.value);
            }
            setLoading(false);
        };

        fetchProjectsAndTeams();
    }, [employeeWithRelations]);

    if (!employeesWithRelations) { return <div>Загрузка списка компаний...</div>; }
    if (!employeeWithRelations) { return <div>Компания не найдена</div>; }
    if (loading) { return <div>Загрузка данных компании...</div>; }
    if (error) { return <div>Ошибка: {error.message}</div>; }

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
                            <Link
                                to={getProjectRoute(projectAndTeams.project)}
                                state={{ employeeWithRelations, projectAndTeams, team: null, timestamp: Date.now() } satisfies CompanyNavigationState}
                            >
                                <h3>{projectAndTeams.project.title}</h3>
                            </Link>
                            {
                                projectAndTeams.teams.length === 0
                                    ? (<p>Нет команд в этом проекте</p>)
                                    : (
                                        <ul>
                                            {projectAndTeams.teams.map((team) => (
                                                <li key={team.id}>
                                                    <Link
                                                        to={getTeamRoute(projectAndTeams.project, team)}
                                                        state={{ employeeWithRelations, projectAndTeams, team, timestamp: Date.now(), }}
                                                    >
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
