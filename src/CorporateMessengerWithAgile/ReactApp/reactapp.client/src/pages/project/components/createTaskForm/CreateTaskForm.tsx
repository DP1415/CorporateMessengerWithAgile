// src/pages/project/components/createTaskForm/CreateTaskForm.tsx
import React, { useState, type FormEvent } from 'react';
import styles from './CreateTaskForm.module.css';

interface CreateTaskFormData {
    title: string;
    description: string;
    priority: number;
    complexity: number;
    deadline: string;
}

interface CreateTaskFormProps {
    onSubmit: (data: CreateTaskFormData) => Promise<void>;
    onCancel: () => void;
    initialData?: CreateTaskFormData;
    isLoading?: boolean;
}

const getDefaultDeadline = (): string => new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).toISOString().split('T')[0];


const getDefaultFormData = (): CreateTaskFormData => ({
    title: '',
    description: '',
    priority: 1,
    complexity: 1,
    deadline: getDefaultDeadline()
});

const CreateTaskForm: React.FC<CreateTaskFormProps> = ({
    onSubmit,
    onCancel,
    initialData,
    isLoading = false
}) => {
    const [formData, setFormData] = useState<CreateTaskFormData>(() => {
        if (initialData) {
            return initialData;
        }
        return getDefaultFormData();
    });

    React.useEffect(() => {
        if (initialData) {
            setFormData(initialData);
        }
    }, [initialData]);

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (!formData.title.trim()) { return; }
        await onSubmit(formData);
    };

    return (
        <form className={styles.createTaskForm} onSubmit={handleSubmit}>
            <h3>Новая задача</h3>

            <div className={styles.formRow}>
                <div className={styles.formGroup}>
                    <label htmlFor="task-title">Название *</label>
                    <input
                        id="task-title"
                        type="text"
                        name="title"
                        value={formData.title}
                        onChange={(e) => setFormData({ ...formData, title: e.target.value })}
                        className={styles.formInput}
                        placeholder="Введите название задачи"
                        required
                        disabled={isLoading}
                        autoFocus
                    />
                </div>
            </div>

            <div className={styles.formRow}>
                <div className={styles.formGroup}>
                    <label htmlFor="task-description">Описание</label>
                    <textarea
                        id="task-description"
                        name="description"
                        value={formData.description}
                        onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                        className={styles.formTextarea}
                        placeholder="Описание задачи"
                        rows={3}
                        disabled={isLoading}
                    />
                </div>
            </div>

            <div className={styles.formRow}>
                <div className={styles.formGroup}>
                    <label htmlFor="task-priority">Приоритет</label>
                    <select
                        id="task-priority"
                        name="priority"
                        value={formData.priority}
                        onChange={(e) => setFormData({ ...formData, priority: parseInt(e.target.value) })}
                        className={styles.formSelect}
                        disabled={isLoading}
                    >
                        <option value={0}>0 - Низкий</option>
                        <option value={1}>1 - Средний</option>
                        <option value={2}>2 - Высокий</option>
                        <option value={3}>3 - Критический</option>
                    </select>
                </div>
                <div className={styles.formGroup}>
                    <label htmlFor="task-complexity">Сложность</label>
                    <select
                        id="task-complexity"
                        name="complexity"
                        value={formData.complexity}
                        onChange={(e) => setFormData({ ...formData, complexity: parseInt(e.target.value) })}
                        className={styles.formSelect}
                        disabled={isLoading}
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
                    <label htmlFor="task-deadline">Дедлайн</label>
                    <input
                        id="task-deadline"
                        type="date"
                        name="deadline"
                        value={formData.deadline}
                        onChange={(e) => setFormData({ ...formData, deadline: e.target.value })}
                        className={styles.formInput}
                        disabled={isLoading}
                    />
                </div>
            </div>

            <div className={styles.formActions}>
                <button
                    type="submit"
                    className={styles.submitButton}
                    disabled={!formData.title.trim() || isLoading}
                >
                    {isLoading ? 'Создание...' : 'Создать задачу'}
                </button>
                <button
                    type="button"
                    className={styles.cancelButton}
                    onClick={onCancel}
                    disabled={isLoading}
                >
                    Отменить
                </button>
            </div>
        </form>
    );
};

export default CreateTaskForm;