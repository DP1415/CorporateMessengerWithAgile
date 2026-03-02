// src/pages/project/components/projectTaskList/ProjectTaskList.tsx
import React, { useState } from 'react';
import styles from './ProjectTaskList.module.css';
import { type TaskItemSummaryDto } from '../../../../models';

interface ProjectTaskListProps {
    tasks: TaskItemSummaryDto[];
}

const ProjectTaskList: React.FC<ProjectTaskListProps> = ({ tasks }) => {
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

    if (tasks.length === 0) {
        return <div className={styles.empty}>Нет задач</div>;
    }

    return (
        <div className={styles.taskList}>
            {
                tasks.map(task =>
                    <div
                        key={task.id}
                        className={`${styles.taskCard} ${expandedTaskId === task.id && styles.expanded}`}
                        onClick={() => toggleExpand(task.id)}
                    >
                        <div className={styles.taskHeader}>
                            <h3 className={styles.taskTitle}>{task.title}</h3>
                            <span className={styles.expandIcon}>
                                {expandedTaskId === task.id ? '−' : '+'}
                            </span>
                        </div>
                        {
                            expandedTaskId === task.id &&
                            <>
                                <hr />
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
                                        <strong>Автор:</strong> {task.authorId || 'Не указан'}
                                    </div>
                                    <div className={styles.metaItem}>
                                        <strong>Ответственный:</strong> {task.responsibleId || 'Не назначен'}
                                    </div>
                                </div>
                                {
                                    task.subtaskIds && task.subtaskIds.length > 0 &&
                                    <div className={styles.subtasks}>
                                        <strong>Подзадачи:</strong>
                                        <ul className={styles.subtaskList}>
                                            {
                                                task.subtaskIds.map(subtaskId =>
                                                    <li key={subtaskId} className={styles.subtask}>
                                                        {subtaskId}
                                                    </li>
                                                )
                                            }
                                        </ul>
                                    </div>
                                }
                            </>
                        }
                    </div>
                )
            }
        </div>
    );
};

export default ProjectTaskList;
