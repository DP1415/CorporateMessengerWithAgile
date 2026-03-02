// src/utils/routeHelpers.ts

//export const encodeParam = (param: string): string => encodeURIComponent(param);
export function EncodeParam(param: string): string { return encodeURIComponent(param); }

export function GetCompanyRoute(companyTitle: string): string {
    return `/company/${EncodeParam(companyTitle)}`;
}
export function GetProjectRoute(companyTitle: string, projectTitle: string): string {
    return `${GetCompanyRoute(companyTitle)}/project/${EncodeParam(projectTitle)}`;
}
export function GetTeamRoute(companyTitle: string, projectTitle: string, teamTitle: string): string {
    return `${GetProjectRoute(companyTitle, projectTitle)}/team/${EncodeParam(teamTitle)}`;
}
