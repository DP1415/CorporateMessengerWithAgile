// src/components/user/TeamPage.tsx
import React, { useState, useEffect } from 'react';
import { useParams, useOutletContext, useLocation } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { AppError, WorkplaceDto, TeamDto, Result, ProjectWithTeamsDto } from '../../models';
import { UserController } from '../../controllers';
import { AppError as AppErrorClass } from '../../models/result/AppError';
import type { CompanyNavigationState } from './CompanyPage';

const TeamPage: React.FC = () => {
    const location = useLocation();
    const navigationState = location.state as CompanyNavigationState | null;

    const { companyTitle, projectTitle, teamTitle } = useParams<{ companyTitle: string; projectTitle: string; teamTitle: string; }>();
    const { workplaces } = useOutletContext<UserLayoutContext>();

    const [workplace, setWorkplace] = useState<WorkplaceDto | null>(null);
    const [teamData, setTeamData] = useState<TeamDto | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<AppError | null>(null);

    useEffect(() => {
        const { workplace, team, timestamp } = navigationState || {};
        if (workplace && team && timestamp) {
            const isDataFresh = Date.now() - timestamp < 5000;
            if (isDataFresh) {
                setWorkplace(workplace);
                setTeamData(team);
                setLoading(false);
                return;
            }
        }

        const loadDataFromApi = async () => {
            setLoading(true);
            setError(null);
            if (!workplaces) {
                setError(new AppErrorClass('!workplaces', 'Workplaces not loaded', -1));
                setLoading(false);
                return;
            }

            if (!companyTitle || !projectTitle || !teamTitle) {
                setError(new AppErrorClass('!params', 'Missing URL parameters', -1));
                setLoading(false);
                return;
            }

            const decodedCompany = decodeURIComponent(companyTitle);
            const targetWorkplace: WorkplaceDto | undefined = workplaces.find(w => w.company.title === decodedCompany);
            if (!targetWorkplace) {
                setError(new AppErrorClass('!company', 'Компания не найдена', -1));
                setLoading(false);
                return;
            }
            setWorkplace(targetWorkplace);

            const controller = new UserController();
            const result: Result<ProjectWithTeamsDto[]> = await controller.getProjectsAndTeams(targetWorkplace.id);
            if (result.isFailure) {
                setError(result.error);
                setLoading(false);
                return;
            }

            const decodedProject = decodeURIComponent(projectTitle);
            const project: ProjectWithTeamsDto | undefined = result.value.find(p => p.project.title === decodedProject);
            if (!project) {
                setError(new AppErrorClass('!project', 'Проект не найден', -1));
                setLoading(false);
                return;
            }

            const decodedTeam = decodeURIComponent(teamTitle);
            const team: TeamDto | undefined = project.teams.find(t => t.title === decodedTeam);
            if (!team) {
                setError(new AppErrorClass('!team', 'Команда не найдена', -1));
                setLoading(false);
                return;
            }
            setTeamData(team);
            setLoading(false);
        };

        loadDataFromApi();
    }, [companyTitle, projectTitle, teamTitle, workplaces, navigationState]);


    if (loading) return <div>Загрузка...</div>;
    if (error) return <div>Ошибка: {error.message}</div>;
    if (!workplace || !teamData) return <div>Команда не найдена</div>;

    return (
        <>
            <h1>Команда: {teamData.title}</h1>
            <p>Компания: {workplace.company.title}</p>
            <p>Проект: {projectTitle}</p>
        </>
    );
};

export default TeamPage;
