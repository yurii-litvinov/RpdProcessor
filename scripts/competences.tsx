import * as React from "react"
import { Competence } from "./model"

type CompetencesProps = {
    competences: Competence[]
}

export class Competences extends React.Component<CompetencesProps> {
    render() {
        if (this.props.competences == null) {
            return null
        }

        let competencesList = this.props.competences.map((c, i) => {
            var description = c.description[0].toLowerCase() + c.description.substring(1)
            const separator = i == this.props.competences.length - 1 ? '.' : ';'
            return <div key={c.code}>{c.code} — {description}{separator}<br /></div>
        })

        const competences =
            <div>
                <h1>Компетенции:</h1>
                {competencesList}
            </div>
        return competences
    }
}
