import * as React from "react"
import { Discipline } from "./model"
import { SemesterInfo } from "./semesterInfo"

type SemesterListProps = {
    discipline: Discipline
}

export class SemesterList extends React.Component<SemesterListProps> {
    render() {
        if (this.props.discipline == null) {
            return null
        }

        let semesters = this.props.discipline.semesters.map((semester) => {
            return <SemesterInfo key={semester.semester} semester={semester} />
        })

        return <div>
            {semesters}
        </div>
    }
}


