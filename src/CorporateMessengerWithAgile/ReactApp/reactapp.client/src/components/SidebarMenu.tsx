// src/components/SidebarMenu.tsx
import React, { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import styles from './SidebarMenu.module.css';
import { type EmployeeWithRelations } from '../controllers';

interface SidebarMenuProps {
    employeesWithRelations: EmployeeWithRelations[] | null;
}

const SidebarMenu: React.FC<SidebarMenuProps> = ({ employeesWithRelations }) => {
    const [sidebarWidth, setSidebarWidth] = useState(270);
    const [isResizing, setIsResizing] = useState(false);
    const sidebarRef = useRef<HTMLDivElement>(null);
    const resizeRef = useRef<HTMLDivElement>(null);

    const minSidebarWidth = 150;
    const maxSidebarWidth = 500;

    const startResizing = (e: React.MouseEvent) => {
        e.preventDefault();
        setIsResizing(true);
    };

    useEffect(() => {
        const handleMouseMove = (e: MouseEvent) => {
            if (!isResizing || !sidebarRef.current) return;

            const newWidth = e.clientX;
            if (newWidth >= minSidebarWidth && newWidth <= maxSidebarWidth) {
                setSidebarWidth(newWidth);
            }
        };

        const handleMouseUp = () => {
            setIsResizing(false);
        };

        if (isResizing) {
            document.addEventListener('mousemove', handleMouseMove);
            document.addEventListener('mouseup', handleMouseUp);
        }

        return () => {
            document.removeEventListener('mousemove', handleMouseMove);
            document.removeEventListener('mouseup', handleMouseUp);
        };
    }, [isResizing]);

    const getCompanyRoute = (companyTitle: string): string => {
        return `/company/${encodeURIComponent(companyTitle)}`;
    };

    return (
        <aside
            ref={sidebarRef}
            className={styles.sidebar}
            style={{ width: `${sidebarWidth}px` }}
        >
            <nav>
                <Link to="/" className={styles.navLink}>Главная</Link>
                <Link to="/profile" className={styles.navLink}>Профиль</Link>

                <div className={styles.divider}></div>

                {employeesWithRelations && employeesWithRelations.length > 0 &&
                    employeesWithRelations.map(
                        employee =>
                            <Link
                                to={getCompanyRoute(employee.company.title)}
                                className={styles.navLink}
                            >
                                {employee.company.title}
                            </Link>
                    )
                }
            </nav>

            <div
                ref={resizeRef}
                className={styles.resizeHandle}
                onMouseDown={startResizing}
            />
        </aside >
    );
};

export default SidebarMenu;