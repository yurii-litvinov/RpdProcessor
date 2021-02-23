import { PlanInfo } from "./model";

export class Utils {
    static planInfoToString(plan: PlanInfo) {
        return `${plan.name}-${plan.year}`
    }
}
