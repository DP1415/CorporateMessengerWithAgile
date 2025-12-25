import type { CompanyGetByIdDto } from '../../models';

interface CompanyDetailProps {
    data: CompanyGetByIdDto;
}

export default function CompanyDetail({ data }: CompanyDetailProps) {
    const { companyDto, projectDtos, employeeDtos, positionInCompanyDtos } = data;

    return (
        <div>
            <h2>{companyDto.title || 'Компания без названия'}</h2>

            <h3>Проекты</h3>
            {projectDtos && projectDtos.length > 0 ? (
                <ul>
                    {projectDtos.map((p) => (
                        <li key={p.id}>{p.title || 'Без названия'}</li>
                    ))}
                </ul>
            ) : (
                <p>Нет проектов</p>
            )}

            <h3>Должности</h3>
            {positionInCompanyDtos && positionInCompanyDtos.length > 0 ? (
                <ul>
                    {positionInCompanyDtos.map((pos) => (
                        <li key={pos.id}>
                            {pos.title || 'Без названия'}: {pos.description}
                        </li>
                    ))}
                </ul>
            ) : (
                <p> Нет должностей</p>
            )
            }

            <h3>Сотрудники</h3>
            {employeeDtos && employeeDtos.length > 0 ? (
                <ul>
                    {employeeDtos.map((emp) => (
                        <li key={emp.id}>ID сотрудника: {emp.id}</li>
                    ))}
                </ul>
            ) : (
                <p>Нет сотрудников</p>
            )
            }
        </div >
    );
}