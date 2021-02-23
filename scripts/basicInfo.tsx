import * as React from "react"
import { Discipline } from "./model"

type BasicInfoProps = {
    discipline: Discipline
}

export class BasicInfo extends React.Component<BasicInfoProps> {
    render() {
        let discipline = this.props.discipline
        if (discipline == null) {
            return null
        }

        let result =
            <div>
                <h1>Дисциплина: [{discipline.code}] "{discipline.name}"</h1>
                Общая трудоёмкость: {discipline.semesters.map((s) => s.laborIntensity).reduce((sum, i) => sum + i, 0)} з.е. (может быть неправдой, если дисциплина имеет разные траектории).
            </div>

        return result
    }
}

