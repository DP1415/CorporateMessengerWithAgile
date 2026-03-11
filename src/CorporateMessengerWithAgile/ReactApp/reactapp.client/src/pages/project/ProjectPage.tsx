// src/pages/project/ProjectPage.tsx
import React, { useEffect, useState } from 'react';
import { useParams, useOutletContext, Link } from 'react-router-dom';
import type { UserLayoutContext } from '../../layouts';
import type { Guid, TaskItemSummaryDto } from '../../models';
import { AppError } from '../../models';
import type { EmployeeWithRelations, ProjectWithTeams } from '../../controllers';
import ProjectTaskList from './components/projectTaskList/ProjectTaskList';
import CreateTaskForm from './components/createTaskForm/CreateTaskForm';
import styles from './ProjectPage.module.css';
import { GetTeamRoute } from '../../utils/routeHelpers';
import { AppErrorDisplay } from '../../components';

interface CreateTaskFormData {
    title: string;
    description: string;
    priority: number;
    complexity: number;
    deadline: string;
}

const ProjectPage: React.FC = () => {
    const { companyTitle, projectTitle } = useParams<{ companyTitle: string; projectTitle: string }>();
    const { controller, employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const [tasks, setTasks] = useState<TaskItemSummaryDto[]>([]);
    const [loading, setLoading] = useState(true);
    const [errorGetTaskItemsByProject, setErrorGetTaskItemsByProject] = useState<AppError | null>(null);
    const [globalError, setGlobalError] = useState<string | null>(null);
    const [projectData, setProjectData] = useState<{
        employeeWithRelations: EmployeeWithRelations;
        projectAndTeams: ProjectWithTeams;
    } | null>(null);

    const [showCreateTaskForm, setShowCreateTaskForm] = useState(false);
    const [isCreatingTask, setIsCreatingTask] = useState(false);

    const getInitialFormData = (): CreateTaskFormData => ({
        title: '',
        description: '',
        priority: 1,
        complexity: 1,
        deadline: new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).toISOString().split('T')[0]
    });

    const [createTaskForm, setCreateTaskForm] = useState<CreateTaskFormData>(getInitialFormData());

    const loadTasks1 = async (projectId: Guid) => {
        try {
            setLoading(true);
            setErrorGetTaskItemsByProject(null);

            const result = await controller.Task.getTaskItemsByProject(projectId);

            if (result.isSuccess && result.value) {
                setTasks(result.value);
            } else {
                setErrorGetTaskItemsByProject(result.error);
            }
        } catch (err) {
            setErrorGetTaskItemsByProject(new AppError("wip", 'Произошла ошибка при загрузке задач', -1));
            console.error('Error loading tasks:', err);
        } finally {
            setLoading(false);
        }
    };

    const fetchTasks = async () => {
        if (!projectData) return;

        try {
            setLoading(true);
            setErrorGetTaskItemsByProject(null);

            const result = await controller.Task.getTaskItemsByProject(
                projectData.projectAndTeams.project.id as unknown as Guid
            );

            if (result.isSuccess && result.value) {
                setTasks(result.value);
            } else {
                setErrorGetTaskItemsByProject(result.error);
            }
        } catch (err) {
            setErrorGetTaskItemsByProject(new AppError("wip", 'Произошла ошибка при загрузке задач', -1));
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

            await loadTasks1(projectAndTeams.project.id);
        };
        loadTasks();
    }, [employeesWithRelations, companyTitle, projectTitle, controller]);

    if (globalError) { return <div>{globalError}</div>; }
    if (!projectData || companyTitle == undefined) { return loading ? <div>Загрузка...</div> : <div>Данные проекта не найдены</div>; }

    const { employeeWithRelations, projectAndTeams } = projectData;

    const handleCreateTaskSubmit = async (data: CreateTaskFormData) => {
        if (!projectData) return;

        setIsCreatingTask(true);
        try {
            const result = await controller.Task.createTaskItem({
                title: data.title,
                description: data.description,
                priority: data.priority,
                complexity: data.complexity,
                deadline: data.deadline,
                projectId: projectData.projectAndTeams.project.id,
                authorId: employeeWithRelations.employeeId,
                responsibleId: employeeWithRelations.employeeId,
                sprintWithLastMentionId: undefined,
                parentTaskId: undefined
            });

            if (result.isSuccess) {
                setShowCreateTaskForm(false);
                setCreateTaskForm(getInitialFormData());
                await fetchTasks();
            } else {
                console.error(`Ошибка создания задачи: ${result.error?.message || 'Неизвестная ошибка'}`);
                alert(`Ошибка: ${result.error?.message || 'Не удалось создать задачу'}`);
            }
        } catch (err) {
            console.error('Critical error creating task:', err);
            alert('Произошла критическая ошибка при создании задачи');
        } finally {
            setIsCreatingTask(false);
        }
    };

    const handleCancelCreate = () => {
        setShowCreateTaskForm(false);
        setCreateTaskForm(getInitialFormData());
    };

    return (<>
        <h1>Проект: {projectAndTeams.project.title}</h1>

        <div className={styles.createTaskSection}>
            <button
                onClick={() => setShowCreateTaskForm(!showCreateTaskForm)}
                disabled={isCreatingTask}
            >
                {showCreateTaskForm ? '− Отменить' : '+ Добавить задачу'}
            </button>

            {showCreateTaskForm &&
                <CreateTaskForm
                    onSubmit={handleCreateTaskSubmit}
                    onCancel={handleCancelCreate}
                    initialData={createTaskForm}
                    isLoading={isCreatingTask}
                />
            }
        </div>

        <hr />
        <h2>Команды проекта</h2>
        {
            projectAndTeams.teams.length > 0
                ? <ul>
                    {
                        projectAndTeams.teams.map(team =>
                            <li key={team.id}>
                                <Link to={GetTeamRoute(companyTitle, projectAndTeams.project.title, team.title)}>
                                    {team.title}
                                </Link>
                            </li>
                        )
                    }
                </ul>
                : <p>Нет команд</p>
        }
        <hr />
        <h2>Задачи</h2>
        {
            loading && !isCreatingTask
                ? <p>Загрузка задач...</p>
                : errorGetTaskItemsByProject
                    ? <>
                        <AppErrorDisplay error={errorGetTaskItemsByProject} />
                        <button onClick={fetchTasks}>Повторить попытку</button>
                    </>
                    : <ProjectTaskList tasks={tasks} />
        }
    </>);
};

export default ProjectPage;