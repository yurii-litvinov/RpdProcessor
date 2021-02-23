import { Semester, WorkloadItem } from "./model"

export enum ApiStatus {
    Ok,
    InProgress,
    DisciplineNotFound,
    CommunicationError
}

export class CoursePart {
    workloads: WorkloadItem[]
}

export class SemesterParts {
    semester: Semester
    parts: CoursePart[]
}
