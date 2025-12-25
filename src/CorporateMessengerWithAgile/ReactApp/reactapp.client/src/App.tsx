// src/App.tsx
import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import CompanyList from './components/company/CompanyList';
import CompanyDetail from './components/company/CompanyDetail';
import { companyApi } from './api/companyApi';
import type { CompanyDto, CompanyGetByIdDto } from './models/typesdto';

const App: React.FC = () => {
    const [companies, setCompanies] = useState<CompanyDto[]>([]);

    useEffect(() => {
        const fetchCompanies = async () => {
            try {
                const data = await companyApi.getAll();
                setCompanies(data);
            } catch (error) {
                console.error('Ошибка при загрузке списка компаний:', error);
            }
        };

        fetchCompanies();
    }, []);

    return (
        <Router>
            <div className="App">
                <Routes>
                    {/* Главная страница — список компаний */}
                    <Route
                        path="/"
                        element={
                            <div style={{ padding: '20px' }}>
                                <h1>Компании</h1>
                                <CompanyList companies={companies} />
                            </div>
                        }
                    />

                    {/* Страница деталей компании */}
                    <Route
                        path="/companies/:id"
                        element={<CompanyDetailWrapper />}
                    />

                    {/* Перенаправление с несуществующих путей на главную */}
                    <Route path="*" element={<Navigate to="/" replace />} />
                </Routes>
            </div>
        </Router>
    );
};

// Отдельный компонент для загрузки данных компании по ID
const CompanyDetailWrapper: React.FC = () => {
    const [data, setData] = useState<CompanyGetByIdDto | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    // Получаем ID из URL
    //const params = new URLSearchParams(window.location.search);
    const pathParts = window.location.pathname.split('/');
    const id = pathParts[pathParts.length - 1]; // Последний сегмент — ID

    useEffect(() => {
        const fetchCompany = async () => {
            try {
                setLoading(true);
                const result = await companyApi.getById(id);
                if (result.isSuccess && result.value) {
                    setData(result.value);
                } else {
                    setError('Компания не найдена');
                }
            } catch (err) {
                console.error('Ошибка загрузки компании:', err);
                setError('Не удалось загрузить данные компании');
            } finally {
                setLoading(false);
            }
        };

        if (id) {
            fetchCompany();
        }
    }, [id]);

    if (loading) return <div style={{ padding: '20px' }}>Загрузка...</div>;
    if (error) return <div style={{ padding: '20px', color: 'red' }}>{error}</div>;
    if (!data) return <div style={{ padding: '20px' }}>Нет данных</div>;

    return (
        <div style={{ padding: '20px' }}>
            <button onClick={() => window.history.back()} style={{ marginBottom: '16px' }}>
                ← Назад к списку
            </button>
            <CompanyDetail data={data} />
        </div>
    );
};

export default App;