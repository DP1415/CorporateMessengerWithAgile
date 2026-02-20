// src/pages/team/components/teamKanbanBoard/TeamKanbanBoard.tsx
import React, { useState } from 'react';
import styles from './TeamKanbanBoard.module.css';
import { type TaskItemWithStatusDto } from '../../../../models';

interface TeamKanbanBoardProps {
    tasks: TaskItemWithStatusDto[];
}

const TeamKanbanBoard: React.FC<TeamKanbanBoardProps> = ({ tasks }) => {
    const [expandedTaskId, setExpandedTaskId] = useState<string | null>(null);

    const toggleExpand = (taskId: string) => {
        setExpandedTaskId(expandedTaskId === taskId ? null : taskId);
    };

    const formatDate = (date: Date | string) => {
        return new Date(date).toLocaleDateString('ru-RU', {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        });
    };

    const getStatusLabel = (status: number) => {
        const statuses: Record<number, string> = {
            0: 'Отменено',
            1: 'Отложено',
            2: 'Доступно',
            3: 'В работе',
            4: 'На тестировании',
            5: 'Готово'
        };
        return statuses[status] || 'Неизвестно';
    };

    const columns = [
        { id: 0, title: 'Отменено', status: 0 },
        { id: 1, title: 'Отложено', status: 1 },
        { id: 2, title: 'Доступно', status: 2 },
        { id: 3, title: 'В работе', status: 3 },
        { id: 4, title: 'На тестировании', status: 4 },
        { id: 5, title: 'Готово', status: 5 },
    ];

    const getTasksByStatus = (status: number) => {
        return tasks.filter(task => task.taskStatus === status);
    };

    return (
        <div className={styles.kanbanBoard}>
            {columns.map(column => {
                const columnTasks = getTasksByStatus(column.status);
                return (
                    <div key={column.id} className={styles.column}>
                        <div className={styles.columnHeader}>
                            <h3>{column.title}</h3>
                            {columnTasks.length != 0 && <span className={styles.taskCount}>{columnTasks.length}</span>}
                        </div>
                        <div className={styles.taskList}>
                            {columnTasks.length === 0 ? (
                                <div className={styles.emptyColumn}>Нет задач</div>
                            ) : (
                                columnTasks.map(task => (
                                    <div
                                        key={task.id}
                                        className={`${styles.taskCard} ${expandedTaskId === task.id ? styles.expanded : ''}`}
                                        onClick={() => toggleExpand(task.id)}
                                    >
                                        <div className={styles.taskHeader}>
                                            <h4 className={styles.taskTitle}>{task.title}</h4>
                                            <span className={styles.expandIcon}>
                                                {expandedTaskId === task.id ? '−' : '+'}
                                            </span>
                                        </div>

                                        {expandedTaskId === task.id && (
                                            <div className={styles.taskDetails}>
                                                <div className={styles.taskDescription}>
                                                    <strong>Описание:</strong> {task.description}
                                                </div>

                                                <div className={styles.taskMeta}>
                                                    <div className={styles.metaItem}>
                                                        <strong>Приоритет:</strong> {task.priority}
                                                    </div>
                                                    <div className={styles.metaItem}>
                                                        <strong>Сложность:</strong> {task.complexity}
                                                    </div>
                                                    <div className={styles.metaItem}>
                                                        <strong>Дедлайн:</strong> {formatDate(task.deadline)}
                                                    </div>
                                                    <div className={styles.metaItem}>
                                                        <strong>Автор:</strong> {task.author?.fullName || 'Не указан'}
                                                    </div>
                                                    <div className={styles.metaItem}>
                                                        <strong>Ответственный:</strong> {task.responsible?.fullName || 'Не назначен'}
                                                    </div>
                                                </div>

                                                {task.subtasks && task.subtasks.length > 0 && (
                                                    <div className={styles.subtasks}>
                                                        <strong>Подзадачи:</strong>
                                                        <ul className={styles.subtaskList}>
                                                            {task.subtasks.map(subtask => (
                                                                <li key={subtask.id} className={styles.subtask}>
                                                                    {subtask.title}
                                                                </li>
                                                            ))}
                                                        </ul>
                                                    </div>
                                                )}
                                            </div>
                                        )}
                                    </div>
                                ))
                            )}
                        </div>
                    </div>
                );
            })}
        </div>
    );
};

export default TeamKanbanBoard;
