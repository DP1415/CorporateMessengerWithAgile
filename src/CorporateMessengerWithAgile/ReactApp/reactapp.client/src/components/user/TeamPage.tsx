// src/components/user/TeamPage.tsx
import React, { useEffect, useState } from 'react';
import { useParams, useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from './UserLayout';
import type { Guid, SprintSummaryDto, TeamSummaryDto, TaskItemWithStatusDto } from '../../models';
import type { EmployeeWithRelations, ProjectWithTeams } from '../../controllers';
import TeamKanbanBoard from './TeamKanbanBoard';
import styles from './TeamPage.module.css';

interface SprintWithTasks {
    sprint: SprintSummaryDto;
    tasks: TaskItemWithStatusDto[];
    loading: boolean;
    error: string | null;
    expanded: boolean;
}

const TeamPage: React.FC = () => {
    const { companyTitle, projectTitle, teamTitle } = useParams<{ companyTitle: string; projectTitle: string; teamTitle: string; }>();
    const { userController, employeesWithRelations } = useOutletContext<UserLayoutContext>();

    const [sprints, setSprints] = useState<SprintWithTasks[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [teamData, setTeamData] = useState<{
        employeeWithRelations: EmployeeWithRelations;
        projectAndTeams: ProjectWithTeams;
        team: TeamSummaryDto;
    } | null>(null);

    useEffect(() => {
        const loadData = async () => {
            const decodedCompanyTitle = decodeURIComponent(companyTitle || '');
            const employeeWithRelations: EmployeeWithRelations | undefined = employeesWithRelations.find(
                emp => emp.company.title === decodedCompanyTitle
            );

            if (!employeeWithRelations) {
                setError("Компания не найдена");
                setLoading(false);
                return;
            }

            const decodedProjectTitle = decodeURIComponent(projectTitle || '');
            const projectAndTeams: ProjectWithTeams | undefined = employeeWithRelations.projectsAndTeams?.find(
                p => p.project.title === decodedProjectTitle
            );

            if (!projectAndTeams) {
                setError("Проект не найден");
                setLoading(false);
                return;
            }

            const decodedTeamTitle = decodeURIComponent(teamTitle || '');
            const team: TeamSummaryDto | undefined = projectAndTeams.teams.find(t => t.title === decodedTeamTitle);

            if (!team) {
                setError("Команда не найдена");
                setLoading(false);
                return;
            }

            setTeamData({
                employeeWithRelations,
                projectAndTeams,
                team
            });

            try {
                setLoading(true);
                setError(null);

                const result = await userController.getSprintsByTeam(team.id as unknown as Guid);

                if (result.isSuccess && result.value) {
                    const initialSprintsWithTasks: SprintWithTasks[] = result.value.map(sprint => ({
                        sprint,
                        tasks: [],
                        loading: false, // Не грузим сразу
                        error: null,
                        expanded: false, // Изначально закрыто
                    }));
                    setSprints(initialSprintsWithTasks);
                } else {
                    setError(result.error?.message || 'Не удалось загрузить спринты');
                }
            } catch (err) {
                setError('Произошла ошибка при загрузке спринтов');
                console.error('Error loading sprints:', err);
            } finally {
                setLoading(false);
            }
        };
        loadData();
    }, [employeesWithRelations, companyTitle, projectTitle, teamTitle, userController]);

    const toggleExpand = async (index: number) => {
        const updatedSprints = [...sprints];
        const sprint = updatedSprints[index];

        // Если уже раскрыт или уже грузится — просто переключаем
        if (sprint.expanded || sprint.loading) {
            sprint.expanded = !sprint.expanded;
            setSprints(updatedSprints);
            return;
        }

        // Если еще не загружены задачи — делаем запрос
        try {
            sprint.loading = true;
            sprint.error = null;
            setSprints([...updatedSprints]); // Обновляем состояние до запроса

            const tasksResult = await userController.getTaskItemsBySprintWithStatus(sprint.sprint.id as unknown as Guid);

            if (tasksResult.isSuccess && tasksResult.value) {
                sprint.tasks = tasksResult.value;
            } else {
                sprint.error = tasksResult.error?.message || 'Не удалось загрузить задачи';
            }
        } catch (err) {
            sprint.error = 'Ошибка при загрузке задач';
            console.error('Error loading tasks:', err);
        } finally {
            sprint.loading = false;
            sprint.expanded = true;
            setSprints([...updatedSprints]);
        }
    };

    if (error) { return <div className={styles.error}>{error}</div>; }
    if (!teamData) { return loading ? <div className={styles.loading}>Загрузка...</div> : <div>Данные команды не найдены</div>; }

    const { employeeWithRelations, projectAndTeams, team } = teamData;

    const formatDate = (date: Date | string) => {
        return new Date(date).toLocaleDateString('ru-RU', {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        });
    };

    return (
        <div className={styles.teamPage}>
            <div className={styles.teamHeader}>
                <h1>Команда: {team.title}</h1>
                <div className={styles.teamInfo}>
                    <span>Компания: {employeeWithRelations.company.title}</span>
                    <span>Проект: {projectAndTeams.project.title}</span>
                </div>
            </div>

            <div className={styles.sprintsSection}>
                <h2>Спринты команды</h2>
                {loading ? (
                    <div className={styles.loading}>Загрузка спринтов...</div>
                ) : sprints.length === 0 ? (
                    <div className={styles.empty}>Нет спринтов</div>
                ) : (
                    <div className={styles.sprintsList}>
                        {sprints.map((sprintWithTasks, index) => (
                            <div key={sprintWithTasks.sprint.id} className={styles.sprintCard}>
                                <div
                                    className={`${styles.sprintHeader} ${sprintWithTasks.expanded ? styles.expanded : ''}`}
                                    onClick={() => toggleExpand(index)}
                                    style={{ cursor: 'pointer' }}
                                >
                                    <h3>Спринт: {formatDate(sprintWithTasks.sprint.dateStart)} - {formatDate(sprintWithTasks.sprint.dateEnd)}</h3>
                                    <span className={styles.expandIcon}>
                                        {sprintWithTasks.expanded ? '-' : '+'}
                                    </span>
                                </div>

                                {sprintWithTasks.expanded && (
                                    <div className={styles.kanbanContainer}>
                                        {sprintWithTasks.loading ? (
                                            <div className={styles.loading}>Загрузка задач...</div>
                                        ) : sprintWithTasks.error ? (
                                            <div className={styles.error}>{sprintWithTasks.error}</div>
                                        ) : (
                                            <TeamKanbanBoard tasks={sprintWithTasks.tasks} />
                                        )}
                                    </div>
                                )}
                            </div>
                        ))}
                    </div>
                )}
            </div>
        </div>
    );
};

export default TeamPage;
