// src/components/user/ProjectPage.tsx
import React, { useState, useEffect } from 'react';
import { useLocation, useParams, useOutletContext, Link } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { AppError, ProjectWithTeamsDto, Result, WorkplaceDto } from '../../models';
import { UserController } from '../../controllers';
import { AppError as AppErrorClass } from '../../models/result/AppError';
import type { CompanyNavigationState } from './CompanyPage';

const ProjectPage: React.FC = () => {
    const location = useLocation();
    const navigationState = location.state as CompanyNavigationState | null;

    const { companyTitle, projectTitle } = useParams<{ companyTitle: string; projectTitle: string }>();
    const { workplaces } = useOutletContext<UserLayoutContext>();

    const [workplace, setWorkplace] = useState<WorkplaceDto | null>(null);
    const [projectAndTeams, setProjectAndTeams] = useState<ProjectWithTeamsDto | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<AppError | null>(null);

    useEffect(() => {
        const { workplace, projectAndTeams, timestamp } = navigationState || {};
        if (workplace && projectAndTeams && timestamp) {
            const isDataFresh = Date.now() - timestamp < 5000;
            if (isDataFresh) {
                setWorkplace(workplace);
                setProjectAndTeams(projectAndTeams);
                setLoading(false);
                return;
            }
        }

        const loadDataFromApi = async () => {
            setLoading(true);
            if (!workplaces) {
                setError(new AppErrorClass('!workplaces', 'Workplaces not loaded', -1));
                setLoading(false);
                return;
            }

            const decodedCompanyTitle = decodeURIComponent(companyTitle || '');
            const targetWorkplace: WorkplaceDto | undefined = workplaces.find(w => w.company.title === decodedCompanyTitle);
            if (!targetWorkplace) {
                setError(new AppErrorClass('!company', 'Компания не найдена', -1));
                setLoading(false);
                return;
            }
            setWorkplace(targetWorkplace);
            setError(null);

            const controller = new UserController();
            const result: Result<ProjectWithTeamsDto[]> = await controller.getProjectsAndTeams(targetWorkplace.id);
            if (result.isFailure) {
                setError(result.error);
                setLoading(false);
                return
            }

            const decodedProjectTitle = decodeURIComponent(projectTitle || '');
            const foundProject: ProjectWithTeamsDto | undefined = result.value.find(p => p.project.title === decodedProjectTitle);

            if (foundProject) setProjectAndTeams(foundProject);
            else setError(new AppErrorClass('!project', 'Проект не найден', -1));

            setLoading(false);
        };

        loadDataFromApi();
    }, [companyTitle, projectTitle, workplaces, navigationState]);



    if (loading) return <div>Загрузка...</div>;
    if (error) return <div>Ошибка: {error.message}</div>;
    if (!workplace || !projectAndTeams) return <div>Проект не найден</div>;

    return (<>
        <h1>Проект: {projectAndTeams.project.title}</h1>
        <p>Компания: {workplace.company.title}</p>

        <h2>Команды проекта</h2>
        {projectAndTeams.teams.length > 0 ? (
            <ul>
                {projectAndTeams.teams.map(team => (
                    <li key={team.id}>
                        <Link to={`/company/${companyTitle}/project/${projectTitle}/team/${encodeURIComponent(team.title)}`}
                            state={{ workplace, projectAndTeams, timestamp: Date.now(), team } satisfies CompanyNavigationState}>
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
