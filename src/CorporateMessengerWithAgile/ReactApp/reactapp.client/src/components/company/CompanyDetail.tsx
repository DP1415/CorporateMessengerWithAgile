import type { CompanyGetByIdDto, PositionInCompanyDto, UserDto } from '../../models';

interface CompanyDetailProps {
    data: CompanyGetByIdDto;
}

export default function CompanyDetail({ data }: CompanyDetailProps) {
    const { companyDto, projectDtos, employeeDtos, positionInCompanyDtos, userDtos } = data;

    // Создаём мапы для быстрого поиска
    const userMap = new Map<string, UserDto>();
    userDtos?.forEach(user => {
        if (user.id) userMap.set(user.id, user);
    });

    const positionMap = new Map<string, PositionInCompanyDto>();
    positionInCompanyDtos?.forEach(pos => {
        if (pos.id) positionMap.set(pos.id, pos);
    });

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
            )}

            <h3>Сотрудники</h3>
            {employeeDtos && employeeDtos.length > 0 ? (
                <ul>
                    {employeeDtos.map((emp) => {
                        const user = emp.userId ? userMap.get(emp.userId) : null;
                        const position = emp.positionInCompanyId
                            ? positionMap.get(emp.positionInCompanyId)
                            : null;

                        return (
                            <li key={emp.id}>
                                {/*<strong>ID:</strong> {emp.id}<br />*/}
                                <strong>Имя:</strong> {user?.username || 'Не указано'}<br />
                                <strong>Email:</strong> {user?.email || 'Не указан'}<br />
                                <strong>Должность:</strong> {position?.title || 'Не назначена'}<br />
                                {position?.description && (
                                    <>
                                        <strong>Описание должности:</strong> {position.description}<br />
                                    </>
                                )}
                            </li>
                        );
                    })}
                </ul>
            ) : (
                <p>Нет сотрудников</p>
            )}
        </div>
    );
}