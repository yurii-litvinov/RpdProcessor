import { PlanInfo } from "./model";

export class Utils {
    static planInfoToString(plan: PlanInfo) {
        return `${plan.name}-${plan.year}`
    }
}

export enum ApiStatus {
    Ok,
    InProgress,
    DisciplineNotFound,
    CommunicationError
}