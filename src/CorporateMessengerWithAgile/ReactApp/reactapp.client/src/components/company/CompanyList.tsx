import type { CompanyDto } from '../../models';
import { Link } from 'react-router-dom';

interface CompanyListProps {
    companies: CompanyDto[];
}

export default function CompanyList({ companies }: CompanyListProps) {
    if (companies.length === 0) {
        return <p>Нет компаний</p>;
    }

    return (
        <ul style={{ listStyle: 'none', padding: 0 }}>
            {companies.map((company) => (
                <li key={company.id} style={{ margin: '8px 0' }}>
                    <Link
                        to={`/companies/${company.id}`}
                        style={{
                            textDecoration: 'none',
                            color: '#007bff',
                            fontSize: '18px',
                        }}
                    >
                        {company.title || 'Без названия'}
                    </Link>
                </li>
            ))}
        </ul>
    );
}