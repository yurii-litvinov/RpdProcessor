import * as React from 'react'
import * as ReactDOM from 'react-dom'
import Button from '@material-ui/core/Button'
import ButtonGroup from '@material-ui/core/ButtonGroup'
import { PropTypes } from '@material-ui/core';

class Competence {
    name: string;
    description: string;
}

class WorkloadItem {
    itemName: string
    hours: number
}

class Workload {
    semester: string
    workTypes: WorkloadItem[]
}

class PlanInfo {
    name: string
    year: string
}


class Utils {
    static planInfoToString(plan: PlanInfo) {
        return `${plan.name}_${plan.year}`
    }
}


type PlanSelectorProps = {
    plans: PlanInfo[]
    selectedPlan: PlanInfo
    onSelectedChanged: (plan: PlanInfo) => void
}

class PlanSelector extends React.Component<PlanSelectorProps> {
    private handleButtonClick = (plan: PlanInfo) => {
        this.props.onSelectedChanged(plan)
    }

    render(): JSX.Element {
        if (this.props.plans == []) {
            return <p>Загрузка учебных планов...</p>
        } else {
            let plans = this.props.plans.map((plan) => {
                let color: PropTypes.Color = plan == this.props.selectedPlan ? "secondary" : "default"
                return <Button
                    color={color}
                    key={Utils.planInfoToString(plan)}
                    onClick={() => { this.handleButtonClick(plan) }}
                >
                    {Utils.planInfoToString(plan)}
                </Button>
            })

            const result =
                <ButtonGroup
                    id="plansGroup"
                    orientation="vertical"
                    color="primary"
                    size="large"
                >
                    {plans}
                </ButtonGroup>
            return result
        }
    }
}

type CompetencePrinterProps = {
    competences: Competence[]
}

class CompetencePrinter extends React.Component<CompetencePrinterProps> {
    render() {
        if (this.props.competences == []) {
            return null
        }

        let competencesList = this.props.competences.map((c, i) => {
            var description = c.description[0].toLowerCase() + c.description.substring(1)
            const separator = i == this.props.competences.length - 1 ? '.' : ';'
            return <p>{c.name} — {description}{separator}</p>
        })

        const competences =
            <div>
                <h1>Компетенции:</h1>
                {competencesList}
            </div>
        return competences
    }
}

type DisciplineCodeInputProps = {
    onDisciplineCodeChanged: (disciplineCode: string) => void
}

class DisciplineCodeInput extends React.Component<DisciplineCodeInputProps> {
    private handleChange = (event: any) => {
        this.props.onDisciplineCodeChanged(event.target.value)
    }

    render() {
        let result =
            <div>
                <h1>Номер РПД:</h1>
                <p>Сюда введите числовой код РПД, например, 002212</p>
                <p><input type="text" onChange={this.handleChange} /></p>
            </div>

        return result
    }
}

type AppState = {
    plans: PlanInfo[]
    selectedPlan: PlanInfo
    competences: Competence[]
}

class App extends React.Component<{}, AppState> {
    state: AppState = {
        plans: [],
        selectedPlan: undefined,
        competences: []
    }

    constructor(props: any) {
        super(props)
        fetch("/workPlans")
            .then(res => res.json())
            .then(
                (data: PlanInfo[]) => {
                    this.setState({ plans: data, selectedPlan: data[0] })
                },
                (_) => { this.setState({ plans: [] }) }
            )
    }

    private handleSelectedPlanChanged = (plan: PlanInfo) => {
        this.setState({ selectedPlan: plan })
    }

    private handleDisciplineCodeChanged = (code: string) => {
        fetch(`/competences/${Utils.planInfoToString(this.state.selectedPlan)}/${code}`)
            .then(res => res.json())
            .then(
                (result: Competence[]) => {
                    this.setState({ competences: result })
                },
                (_) => { }
            )
    }

    render() {
        let result =
            <div>
                <PlanSelector
                        plans={this.state.plans}
                        selectedPlan={this.state.selectedPlan}
                    onSelectedChanged={this.handleSelectedPlanChanged} />
                <DisciplineCodeInput onDisciplineCodeChanged={this.handleDisciplineCodeChanged} />
                <CompetencePrinter competences={this.state.competences} />
            </div>
        return result
    }
}



// Some old functions here.




function renderSemesterWorkload(workload: Workload) {
    let workloadList = []
    for (let item of workload.workTypes) {
        workloadList.push(
            <tr>
                <td>{item.itemName}</td>
                <td>{item.hours}</td>
            </tr>
        )
    }

    const result = 
        <div>
            <h2>Семестр {workload.semester}</h2>
            <table>
                <tbody>
                    {workloadList}
                </tbody>
            </table>
        </div>

    return result
}

function fetchHours(hoursDiv: HTMLDivElement, rpdNum: string) {
    fetch("/hours/" + rpdNum)
        .then(res => res.json())
        .then(
            (result: Workload[]) => {
                let semesters = []
                for (let semesterWorkload of result) {
                    semesters.push(renderSemesterWorkload(semesterWorkload))
                }

                const workload =
                    <div>
                        <h1>Нагрузка:</h1>
                        {semesters}
                    </div>

                ReactDOM.render(workload, hoursDiv);
            },
            (_) => { ReactDOM.render(<p>Server communication error!</p>, hoursDiv); }
        )
}

export function showRpdInfo() {
    const rpdNum = (document.getElementById("rpdCode") as HTMLInputElement).value;
    let hoursDiv = document.getElementById("hours") as HTMLDivElement;

    ReactDOM.render(<p>Загрузка...</p>, competencesDiv);
    ReactDOM.render(<p>Загрузка...</p>, hoursDiv);

    fetchHours(hoursDiv, rpdNum)
}

export function render() {
    let plansDiv = document.getElementById("root") as HTMLDivElement
    ReactDOM.render(<App />, plansDiv)
}
