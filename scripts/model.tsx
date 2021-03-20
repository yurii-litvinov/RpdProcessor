export class PlanInfo {
    name: string
    year: string
}

export class Competence {
    code: string;
    description: string;
}

export class WorkloadItem {
    name: string
    hours: number
}

export class Semester {
    semester: number
    laborIntensity: number
    attestationType: string
    workload: WorkloadItem[]
}

export class Discipline {
    code: string
    name: string
    formedCompetences: Competence[]
    improvedCompetences: Competence[]
    fullyFormedCompetences: Competence[]
    semesters: Semester[]
}
