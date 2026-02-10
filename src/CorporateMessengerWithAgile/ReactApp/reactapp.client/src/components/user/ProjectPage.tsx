// src/components/user/ProjectPage.tsx
import React, { useEffect, useState } from 'react';
import { useParams, useOutletContext, Link } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { Guid, TaskItemSummaryDto, TeamSummaryDto } from '../../models';
import type { EmployeeWithRelations, ProjectWithTeams } from '../../controllers';
import { UserController } from '../../controllers';
import KanbanBoard from './KanbanBoard';

const ProjectPage: React.FC = () => {
    const { companyTitle, projectTitle } = useParams<{ companyTitle: string; projectTitle: string }>();
    const { employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const [tasks, setTasks] = useState<TaskItemSummaryDto[]>([]);
    const [loading, setLoading] = useState(true);
    const [errorGetTaskItemsByProject, setErrorGetTaskItemsByProject] = useState<string | null>(null);
    const [globalError, setGlobalError] = useState<string | null>(null);
    const [projectData, setProjectData] = useState<{
        employeeWithRelations: EmployeeWithRelations;
        projectAndTeams: ProjectWithTeams;
    } | null>(null);

    const fetchTasks = async () => {
        if (!projectData) return;

        try {
            setLoading(true);
            setErrorGetTaskItemsByProject(null);

            const userController = new UserController();
            const result = await userController.getTaskItemsByProject(
                projectData.projectAndTeams.project.id as unknown as Guid
            );

            if (result.isSuccess && result.value) {
                setTasks(result.value);
            } else {
                setErrorGetTaskItemsByProject(result.error?.message || 'Не удалось загрузить задачи');
            }
        } catch (err) {
            setErrorGetTaskItemsByProject('Произошла ошибка при загрузке задач');
            console.error('Error loading tasks:', err);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        const loadTasks = async () => {
            const decodedCompanyTitle = decodeURIComponent(companyTitle || '');
            const employeeWithRelations: EmployeeWithRelations | undefined = employeesWithRelations.find(
                emp => emp.company.title === decodedCompanyTitle
            );

            if (!employeeWithRelations) {
                setGlobalError("Компания не найдена");
                setLoading(false);
                return;
            }

            const decodedProjectTitle = decodeURIComponent(projectTitle || '');
            const projectAndTeams: ProjectWithTeams | undefined = employeeWithRelations.projectsAndTeams?.find(
                p => p.project.title === decodedProjectTitle
            );

            if (!projectAndTeams) {
                setGlobalError("Проект не найден");
                setLoading(false);
                return;
            }

            setProjectData({
                employeeWithRelations,
                projectAndTeams
            });

            try {
                setLoading(true);
                setErrorGetTaskItemsByProject(null);

                const userController = new UserController();
                const result = await userController.getTaskItemsByProject(
                    projectAndTeams.project.id as unknown as Guid
                );

                if (result.isSuccess && result.value) {
                    setTasks(result.value);
                } else {
                    setErrorGetTaskItemsByProject(result.error?.message || 'Не удалось загрузить задачи');
                }
            } catch (err) {
                setErrorGetTaskItemsByProject('Произошла ошибка при загрузке задач');
                console.error('Error loading tasks:', err);
            } finally {
                setLoading(false);
            }
        };
        loadTasks();
    }, [employeesWithRelations, companyTitle, projectTitle]);

    if (globalError) { return <div>{globalError}</div>; }
    if (!projectData) { return loading ? <div>Загрузка...</div> : <div>Данные проекта не найдены</div>; }

    const { employeeWithRelations, projectAndTeams } = projectData;

    const getTeamRoute = (team: TeamSummaryDto): string =>
        `/company/${companyTitle}/project/${encodeURIComponent(projectAndTeams.project.title)}/team/${encodeURIComponent(team.title)}`;

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

        {loading ? (
            <div>Загрузка задач...</div>
        ) : errorGetTaskItemsByProject ? (
            <div>
                <p>{errorGetTaskItemsByProject}</p>
                <button onClick={() => fetchTasks()}>Повторить попытку</button>
            </div >
        ) : (
            <KanbanBoard tasks={tasks} />
        )}
    </>);
};

export default ProjectPage;
