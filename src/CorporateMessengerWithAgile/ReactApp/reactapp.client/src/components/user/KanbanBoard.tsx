// src/components/user/KanbanBoard.tsx
import React from 'react';
import type { TaskItemSummaryDto } from '../../models';
import styles from './KanbanBoard.module.css';

interface KanbanBoardProps {
    tasks: TaskItemSummaryDto[];
}

type TaskStatus = 'ToDo' | 'InProgress' | 'Done';

interface KanbanColumn {
    id: TaskStatus;
    title: string;
    tasks: TaskItemSummaryDto[];
}

const KanbanBoard: React.FC<KanbanBoardProps> = ({ tasks }) => {
    const columns: KanbanColumn[] = [
        {
            id: 'ToDo',
            title: 'К выполнению',
            tasks: tasks.filter(task => {
                return !task.deadline;
            })
        },
        {
            id: 'InProgress',
            title: 'В работе',
            tasks: tasks.filter(task => {
                return task.deadline && new Date(task.deadline) >= new Date();
            })
        },
        {
            id: 'Done',
            title: 'Выполнено',
            tasks: tasks.filter(task => {
                return task.deadline && new Date(task.deadline) < new Date();
            })
        }
    ];

    const totalTasks = columns.reduce((sum, col) => sum + col.tasks.length, 0);

    return (
        <div className={styles.kanbanBoard}>
            <div className={styles.kanbanHeader}>
                <h2>Канбан-доска</h2>
                <span className={styles.kanbanTaskCount}>Всего задач: {totalTasks}</span>
            </div>
            <div className={styles.kanbanColumns}>
                {columns.map(column => (
                    <div key={column.id} className={styles.kanbanColumn}>
                        <div className={styles.kanbanColumnHeader}>
                            <h3>{column.title}</h3>
                            <span className={styles.kanbanColumnCount}>{column.tasks.length}</span>
                        </div>
                        <div className={styles.kanbanColumnTasks}>
                            {column.tasks.map(task => (
                                <div key={task.id} className={styles.kanbanTaskCard}>
                                    <div className={styles.kanbanTaskHeader}>
                                        <h4>{task.title}</h4>
                                        <span className={styles.kanbanTaskPriority}>
                                            Приоритет: {task.priority}
                                        </span>
                                    </div>
                                    <div className={styles.kanbanTaskDescription}>
                                        {task.description}
                                    </div>
                                    <div className={styles.kanbanTaskMeta}>
                                        <div className={styles.kanbanTaskInfo}>
                                            <span>Сложность: {task.complexity}</span>
                                        </div>
                                        {task.deadline && (
                                            <div className={styles.kanbanTaskDeadline}>
                                                Дедлайн: {new Date(task.deadline).toLocaleDateString('ru-RU')}
                                            </div>
                                        )}
                                    </div>
                                </div>
                            ))}
                            {column.tasks.length === 0 && (
                                <div className={styles.kanbanEmptyColumn}>
                                    Нет задач
                                </div>
                            )}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default KanbanBoard;