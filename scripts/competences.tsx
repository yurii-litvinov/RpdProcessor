import { FormControlLabel, FormGroup, Switch } from "@material-ui/core";
import * as React from "react"
import { Competence } from "./model"

type CompetencesProps = {
    formedCompetences: Competence[]
    improvedCompetences: Competence[]
    fullyFormedCompetences: Competence[]
}

type CompetencesState = {
    sortByState: boolean
}

/// Control that prints information about competences formed by discipline, in ready-to-copypaste form.
/// It works in two different modes --- all competences in one list for section 1 of working program,
/// and competences by forming status, for section 3.
export class Competences extends React.Component<CompetencesProps, CompetencesState> {

    state: CompetencesState

    constructor(props: CompetencesProps) {
        super(props);
        this.state = { sortByState: false }
    }

    private handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ sortByState: event.target.checked })
    }

    private static printCompetence(competence: Competence, isLast: boolean) {
        var description = competence.description[0].toLowerCase() + competence.description.substring(1)
        if (description.charAt(description.length - 1) == '.') {
            description = description.substring(0, description.length - 1)
        }
        const separator = isLast ? '.' : ';'
        return <div key={competence.code}>{competence.code} — {description}{separator}<br /></div>
    }

    render() {
        if (this.props.formedCompetences == null
            && this.props.improvedCompetences == null
            && this.props.fullyFormedCompetences == null)
        {
            return null
        }

        let competencesFormattingSwitch =
            <FormGroup>
              <FormControlLabel
                control={<Switch
                    checked={this.state.sortByState}
                    onChange={this.handleChange}
                    color="primary"
                    name="checkedB"
                    inputProps={{ 'aria-label': 'primary checkbox' }}
                />}
                label="Разбить компетенции по степени сформированности"
              />
            </FormGroup>

        if (!this.state.sortByState) {
            let competences =
                this.props.formedCompetences
                    .concat(this.props.improvedCompetences)
                    .concat(this.props.fullyFormedCompetences)

            competences = competences.reduce((state: Competence[], cur: Competence) => {
                if (state.find(c => c.code == cur.code) == undefined) {
                    state.push(cur)
                }
                return state
            }, [])

            competences = competences.sort((c1, c2) => c1.code.localeCompare(c2.code))

            let competencesList =
                competences.map((c, i) => Competences.printCompetence(c, i == competences.length - 1))

            const result =
                <div>
                    <h1>Компетенции:</h1>
                    {competencesFormattingSwitch}
                    Дисциплина способствует развитию следующих компетенций:<br />
                    {competencesList}
                </div>
            return result
        } else {
            let formatCompetencesList = (competences: Competence[]) =>
                competences.map((c, i) => Competences.printCompetence(c, i == competences.length - 1))

            let formedCompetences = formatCompetencesList(this.props.formedCompetences)
            let improvedCompetences = formatCompetencesList(this.props.improvedCompetences)
            let fullyFormedCompetences = formatCompetencesList(this.props.fullyFormedCompetences)

            const result =
                <div>
                    <h1>Компетенции:</h1>
                    {competencesFormattingSwitch}
                    Компетенции, впервые формируемые дисциплиной:<br />
                    {formedCompetences.length == 0 ? <p>Нет</p> : formedCompetences} <br />
                    Компетенции, развиваемые дисциплиной:<br />
                    {improvedCompetences.length == 0 ? <p>Нет</p> : improvedCompetences} <br />
                    Компетенции, полностью сформированные по результатам освоения дисциплины:<br />
                    {fullyFormedCompetences.length == 0 ? <p>Нет</p> : fullyFormedCompetences} <br />
                </div>
            return result
        }
    }
}
