// src/components/CompanyPage.tsx
import React, { useState, useEffect } from 'react';
import { useParams, useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { AppError, ProjectWithTeamsDto, Result, WorkplaceDto } from '../../models';
import { UserController } from '../../controllers';

const CompanyPage: React.FC = () => {
    const { companyTitle } = useParams<{ companyTitle: string }>();
    const { workplaces } = useOutletContext<UserLayoutContext>();

    const [projectsAndTeams, setProjectsAndTeams] = useState<ProjectWithTeamsDto[] | null>(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<AppError | null>(null);

    const decodedTitle = decodeURIComponent(companyTitle || '');
    const workplace: WorkplaceDto | undefined = decodedTitle && workplaces
        ? workplaces.find(w => w.company.title === decodedTitle)
        : undefined;

    useEffect(() => {
        if (!workplace) {
            // eslint-disable-next-line react-hooks/set-state-in-effect
            setProjectsAndTeams(null);
            setError(null);
            return;
        }

        let isCancelled = false;

        const fetchProjectsAndTeams = async () => {
            setLoading(true);
            setError(null);

            const controller = new UserController();
            const result: Result<ProjectWithTeamsDto[]> = await controller.getProjectsAndTeams(workplace.id);

            if (isCancelled) return;

            if (result.isFailure) {
                setError(result.error);
                setProjectsAndTeams(null);
            } else {
                setProjectsAndTeams(result.value);
            }
            setLoading(false);
        };

        fetchProjectsAndTeams();

        return () => {
            isCancelled = true;
        };
    }, [workplace]);

    if (!workplaces) { return <div>Загрузка списка компаний...</div>; }
    if (!workplace) { return <div>Компания не найдена</div>; }
    if (loading) { return <div>Загрузка данных компании...</div>; }
    if (error) { return <div>Ошибка: {error.message}</div>; }

    const projectList = projectsAndTeams || [];

    return (
        <>
            <h1>{workplace.company.title}</h1>

            <h2>Информация о компании</h2>
            <p>ID: {workplace.company.id}</p>

            <h2>Должность в компании</h2>
            <p><strong>{workplace.positionInCompany.title}</strong></p>
            <p>{workplace.positionInCompany.description}</p>

            <h2>Проекты и команды</h2>
            {
                projectList.length === 0 ? (
                    <p>Нет проектов</p>
                ) : (
                    projectList.map((item) => (
                        <div key={item.project.id}>
                            <h3>{item.project.title}</h3>
                            {item.teams.length > 0 ? (
                                <ul>
                                    {item.teams.map((team) => (
                                        <li key={team.id}>{team.title}</li>
                                    ))}
                                </ul>
                            ) : (
                                <p>Нет команд в этом проекте</p>
                            )}
                        </div>
                    ))
                )
            }
        </>
    );
};

export default CompanyPage;