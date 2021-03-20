import * as React from 'react'
import * as ReactDOM from 'react-dom'

import { PlanInfo, Discipline, Semester } from './model'
import { Utils } from './utils';
import { PlanSelector } from './planSelector';
import { Competences } from './competences';
import { DisciplineCodeInput } from './disciplineCodeInput';
import { BasicInfo } from './basicInfo';
import { SemesterList } from './semesterList';
import { CourseStructureEditor, CourseStructureLogic } from './courseStructureEditor';
import { ApiStatus, CoursePart, SemesterParts } from './commonTypes';

declare var plansList: PlanInfo[]

type AppState = {
    plans: PlanInfo[]
    selectedPlan: PlanInfo
    discipline: Discipline
    status: ApiStatus
    courseParts: SemesterParts[]
}

class App extends React.Component<{}, AppState> {
    state: AppState
    disciplineCode: string = ""

    constructor(props: any) {
        super(props)
        let data: PlanInfo[] = plansList
        this.state = {
            plans: data, selectedPlan: data[0], discipline: null, status: ApiStatus.Ok, courseParts: []
        }
    }

    private fetchDisciplineInfo = (plan: PlanInfo) => {
        if (this.disciplineCode.length == 6) {
            this.setState({ status: ApiStatus.InProgress, discipline: null })
            fetch(`/disciplineInfo/${Utils.planInfoToString(plan)}/${this.disciplineCode}`)
                .then(res => res.json())
                .then(
                    (result: Discipline) => {
                        if (result != null) {
                            let parts = CourseStructureLogic.initCourseParts(result)
                            this.setState({ discipline: result, status: ApiStatus.Ok, courseParts: parts })
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

    private handleAddPartClick = (semester: Semester) => {
        this.setState((state, _) => {
            let parts = state.courseParts
            let s = parts.find(p => p.semester == semester)
            s.parts.push(CourseStructureLogic.createNewPart(semester))
            return {
                courseParts: parts
            }
        })
    }

    private handleUpdateHours = (semester: Semester, parts: CoursePart[]) => {
        this.setState((state, _) => {
            let semesterParts = state.courseParts
            let semesterPart = semesterParts.find(v => v.semester == semester)
            semesterPart.parts = parts
            return { courseParts: semesterParts }
        })
    }

    private handleHoursChange = (part: CoursePart, index: number, value: number) => {
        this.setState((state, _) => {
            part.workloads[index].hours = value
            return {
                courseParts: state.courseParts
            }
        })
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
                <Competences
                    formedCompetences={this.state.discipline?.formedCompetences}
                    improvedCompetences={this.state.discipline?.improvedCompetences}
                    fullyFormedCompetences={this.state.discipline?.fullyFormedCompetences}
                />
                <SemesterList discipline={this.state.discipline} />
                <CourseStructureEditor
                    discipline={this.state.discipline}
                    courseParts={this.state.courseParts}
                    onNewPart={this.handleAddPartClick}
                    onHoursChange={this.handleHoursChange}
                    onUpdateHours={this.handleUpdateHours}
                />
            </div>
        return result
    }
}

export function render() {
    let plansDiv = document.getElementById("root") as HTMLDivElement
    ReactDOM.render(<App />, plansDiv)
}
