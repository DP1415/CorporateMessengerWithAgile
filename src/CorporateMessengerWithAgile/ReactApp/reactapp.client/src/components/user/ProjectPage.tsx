// src/components/user/ProjectPage.tsx
import React, { useEffect, useState } from 'react';
import { useParams, useOutletContext, Link } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';
import type { Guid, TaskItemSummaryDto, TeamSummaryDto } from '../../models';
import type { EmployeeWithRelations, ProjectWithTeams } from '../../controllers';
import { UserController } from '../../controllers';
import ProjectTaskList from './ProjectTaskList';
import styles from './ProjectPage.module.css';

interface CreateTaskFormData {
    title: string;
    description: string;
    priority: number;
    complexity: number;
    deadline: string;
}

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
    const [showCreateTaskForm, setShowCreateTaskForm] = useState(false);
    const [createTaskForm, setCreateTaskForm] = useState<CreateTaskFormData>({
        title: '',
        description: '',
        priority: 1,
        complexity: 1,
        deadline: new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).toISOString().split('T')[0]
    });

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

    const handleCreateTask = async () => {
        if (!projectData) return;

        const userController = new UserController();
        const result = await userController.createTaskItem({
            title: createTaskForm.title,
            description: createTaskForm.description,
            priority: createTaskForm.priority,
            complexity: createTaskForm.complexity,
            deadline: createTaskForm.deadline,
            projectId: projectData.projectAndTeams.project.id,
            authorId: employeeWithRelations.employeeId,
            responsibleId: employeeWithRelations.employeeId,
            sprintWithLastMentionId: undefined,
            parentTaskId: undefined
        });

        if (result.isSuccess) {
            setShowCreateTaskForm(false);
            setCreateTaskForm({
                title: '',
                description: '',
                priority: 1,
                complexity: 1,
                deadline: new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).toISOString().split('T')[0]
            });
            await fetchTasks();
        } else {
            console.error(`Ошибка создания задачи: ${result.error?.message || 'Неизвестная ошибка'}`);
        }
    };

    return (<>
        <h1>Проект: {projectAndTeams.project.title}</h1>
        <p>Компания: {employeeWithRelations.company.title}</p>

        <div className={styles.createTaskSection}>
            <button
                className={styles.createTaskButton}
                onClick={() => setShowCreateTaskForm(!showCreateTaskForm)}
            >
                {showCreateTaskForm ? '− Отменить' : '+ Добавить задачу'}
            </button>

            {showCreateTaskForm && (
                <div className={styles.createTaskForm}>
                    <h3>Новая задача</h3>
                    <div className={styles.formRow}>
                        <div className={styles.formGroup}>
                            <label>Название *</label>
                            <input
                                type="text"
                                value={createTaskForm.title}
                                onChange={(e) => setCreateTaskForm({...createTaskForm, title: e.target.value})}
                                className={styles.formInput}
                                placeholder="Введите название задачи"
                                required
                            />
                        </div>
                    </div>
                    <div className={styles.formRow}>
                        <div className={styles.formGroup}>
                            <label>Описание</label>
                            <textarea
                                value={createTaskForm.description}
                                onChange={(e) => setCreateTaskForm({...createTaskForm, description: e.target.value})}
                                className={styles.formTextarea}
                                placeholder="Описание задачи"
                                rows={3}
                            />
                        </div>
                    </div>
                    <div className={styles.formRow}>
                        <div className={styles.formGroup}>
                            <label>Приоритет</label>
                            <select
                                value={createTaskForm.priority}
                                onChange={(e) => setCreateTaskForm({...createTaskForm, priority: parseInt(e.target.value)})}
                                className={styles.formSelect}
                            >
                                <option value={0}>0 - Низкий</option>
                                <option value={1}>1 - Средний</option>
                                <option value={2}>2 - Высокий</option>
                                <option value={3}>3 - Критический</option>
                            </select>
                        </div>
                        <div className={styles.formGroup}>
                            <label>Сложность</label>
                            <select
                                value={createTaskForm.complexity}
                                onChange={(e) => setCreateTaskForm({...createTaskForm, complexity: parseInt(e.target.value)})}
                                className={styles.formSelect}
                            >
                                <option value={0}>0 - Легкий</option>
                                <option value={1}>1 - Средний</option>
                                <option value={2}>2 - Сложный</option>
                                <option value={3}>3 - Очень сложный</option>
                            </select>
                        </div>
                    </div>
                    <div className={styles.formRow}>
                        <div className={styles.formGroup}>
                            <label>Дедлайн</label>
                            <input
                                type="date"
                                value={createTaskForm.deadline}
                                onChange={(e) => setCreateTaskForm({...createTaskForm, deadline: e.target.value})}
                                className={styles.formInput}
                            />
                        </div>
                    </div>
                    <div className={styles.formActions}>
                        <button
                            className={styles.submitButton}
                            onClick={handleCreateTask}
                            disabled={!createTaskForm.title}
                        >
                            Создать задачу
                        </button>
                    </div>
                </div>
            )}
        </div>

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
            <ProjectTaskList tasks={tasks} />
        )}
    </>);
};

export default ProjectPage;
