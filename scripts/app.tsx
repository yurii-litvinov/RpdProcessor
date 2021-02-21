import * as React from 'react'
import * as ReactDOM from 'react-dom'

import { PlanInfo, Discipline } from './model'
import { ApiStatus, Utils } from './utils';
import { PlanSelector } from './planSelector';
import { Competences } from './competences';
import { DisciplineCodeInput } from './disciplineCodeInput';
import { BasicInfo } from './basicInfo';
import { SemesterList } from './semesterList';

declare var plansList: PlanInfo[]

type AppState = {
    plans: PlanInfo[]
    selectedPlan: PlanInfo
    discipline: Discipline
    status: ApiStatus
}

class App extends React.Component<{}, AppState> {
    state: AppState
    disciplineCode: string = ""

    constructor(props: any) {
        super(props)
        let data: PlanInfo[] = plansList
        this.state = {
            plans: data, selectedPlan: data[0], discipline: null, status: ApiStatus.Ok }
    }

    private fetchDisciplineInfo = (plan: PlanInfo) => {
        if (this.disciplineCode.length == 6) {
            this.setState({ status: ApiStatus.InProgress, discipline: null })
            fetch(`/disciplineInfo/${Utils.planInfoToString(plan)}/${this.disciplineCode}`)
                .then(res => res.json())
                .then(
                    (result: Discipline) => {
                        if (result != null) {
                            this.setState({ discipline: result, status: ApiStatus.Ok })
                        } else {
                            this.setState({ status: ApiStatus.DisciplineNotFound })
                        }
                    },
                    (_) => { this.setState({ status: ApiStatus.CommunicationError }) }
                )
        }
    }

    private handleSelectedPlanChanged = (plan: PlanInfo) => {
        if (this.state.selectedPlan != plan) {
            this.setState({ selectedPlan: plan })
            this.fetchDisciplineInfo(plan)
        }
    }

    private handleDisciplineCodeChanged = (code: string) => {
        if (code.length == 6) {
            this.disciplineCode = code
            this.fetchDisciplineInfo(this.state.selectedPlan)
        }
        // else just ignore this, someone not finished typing.
    }

    render() {
        let result =
            <div>
                <PlanSelector
                    plans={this.state.plans}
                    selectedPlan={this.state.selectedPlan}
                    onSelectedChanged={this.handleSelectedPlanChanged} />
                <DisciplineCodeInput
                    onDisciplineCodeChanged={this.handleDisciplineCodeChanged}
                    apiStatus={this.state.status} />
                <BasicInfo discipline={this.state.discipline} />
                <Competences competences={this.state.discipline?.competences} />
                <SemesterList discipline={this.state.discipline} />
            </div>
        return result
    }
}

export function render() {
    let plansDiv = document.getElementById("root") as HTMLDivElement
    ReactDOM.render(<App />, plansDiv)
}
