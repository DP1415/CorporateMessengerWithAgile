// src/components/CompanyPage.tsx
import React from 'react';
import { useParams, useOutletContext } from 'react-router-dom';
import type { UserLayoutContext } from '../UserLayout';

const CompanyPage: React.FC = () => {
    const { companyTitle } = useParams<{ companyTitle: string }>();
    const { workplaces } = useOutletContext<UserLayoutContext>();

    if (!workplaces) return <div>Загрузка...</div>;

    const decodedCompanyTitle = decodeURIComponent(companyTitle || '');
    const workplace = workplaces.find(w => w.company.title === decodedCompanyTitle);
    if (!workplace) return <div>Компания не найдена</div>;

    return (
        <div>
            <h1>{workplace.company.title}</h1>
            <div>
                <h2>Информация о компании</h2>
                <p>ID: {workplace.company.id}</p>
            </div>
            <div>
                <h2>Должность в компании</h2>
                <p>Название: {workplace.positionInCompany.title}</p>
                <p>Описание: {workplace.positionInCompany.description}</p>
            </div>
            {workplace.teamMembers && workplace.teamMembers.length > 0 && (
                <div>
                    <h2>Команды</h2>
                    <ul>
                        {workplace.teamMembers.map(
                            tm => (<li key={tm.id}>ID: {tm.teamId}</li>)
                        )}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default CompanyPage;
