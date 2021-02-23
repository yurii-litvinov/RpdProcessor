import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField } from "@material-ui/core"
import * as React from "react"
import { CoursePart, SemesterParts } from "./commonTypes"
import { Discipline, Semester } from "./model"

type CourseStructureEditorProps = {
    discipline: Discipline,
    courseParts: SemesterParts[]
    onNewPart: (semester: Semester) => void
    onUpdateHours: (semester: Semester, parts: CoursePart[]) => void
    onHoursChange: (part: CoursePart, index: number, value: number) => void
}

export class CourseStructureLogic {
    private static readonly correctWorkloadOrder = [
        "Лекции",
        "Семинары",
        "Практические занятия",
        "Лабораторные работы",
        "Контрольные работы",
        "Текущий контроль",
        "Под руководством преподавателя (сам. раб.)",
        "В присутствии преподавателя (сам. раб.)",
        "В т.ч. с использованием учебно-методич. материалов (сам. раб.)"
    ]

    static initPart(semester: Semester) {
        let workload = semester.workload
        let part = new CoursePart()
        part.workloads = []

        this.correctWorkloadOrder.forEach(v => {
            let workloadItem = workload.find(w => w.name == v)
            if (workloadItem.hours > 0) {
                part.workloads.push({ name: workloadItem.name, hours: workloadItem.hours })
            }
        })

        return part
    }

    static initCourseParts(discipline: Discipline): SemesterParts[] {
        return discipline.semesters.map(s => ({ semester: s, parts: [this.initPart(s)] }))
    }

    static createNewPart(semester: Semester): CoursePart {
        let newPart = this.initPart(semester)
        newPart.workloads = newPart.workloads.map(v => ({ name: v.name, hours: 0 }))
        return newPart
    }
}

type WeightedWorkItem = {
    name: string,
    weights: number[]
}

export class CourseStructureEditor extends React.Component<CourseStructureEditorProps> {
    private handleAddPartClick = (semester: Semester) => {
        this.props.onNewPart(semester)
    }

    private handleAutoFillClick = (semester: Semester) => {
        let parts = this.props.courseParts.find(p => p.semester == semester).parts
        let sum = parts.reduce((prev, cur) => CourseStructureEditor.addParts(prev, cur))

        let target = CourseStructureLogic.initPart(semester)
        let weights: WeightedWorkItem[] = []

        if (sum.workloads[0].hours == 0) {
            weights = target.workloads.map(i => ({ name: i.name, weights: Array.from({ length: parts.length }).map(_ => 1) }))
        } else {
            target.workloads.forEach(w => weights.push({ name: w.name, weights: parts.map(p => p.workloads[0].hours) }))
        }

        let budgets: Map<string, number> = new Map()
        target.workloads.forEach(w => budgets.set(w.name, w.hours - (sum.workloads.find(wl => wl.name == w.name).hours)))

        target.workloads.forEach(w => {
            const weightArray = weights.find(wt => wt.name == w.name).weights
            const unlockedWeights = weightArray.map((v, idx) => parts[idx].workloads.find(x => x.name == w.name).hours == 0 ? v : 0)
            const weightSum = unlockedWeights.reduce((p, c) => p + c)
            parts = parts.map((cp, i) => {
                let workItem = cp.workloads.find(wi => wi.name == w.name)
                if (workItem.hours == 0) {
                    workItem.hours = Math.round(budgets.get(w.name) * unlockedWeights[i] / weightSum)
                }
                return cp
            })
        })

        this.props.onUpdateHours(semester, parts)
    }

    private handleHoursChange = (event: any, part: CoursePart, index: number) => {
        if (!Number.isNaN(+event.target.value)) {
            this.props.onHoursChange(part, index, +event.target.value)
        }
    }

    private renderPart = (part: CoursePart, partIndex: number, workloadsCount: number) => {
        return part.workloads.map((value, index) => {
            return <TableRow key={value.name}>
                {index == 0 ? <TableCell rowSpan={workloadsCount}>{partIndex + 1}.</TableCell> : null}
                <TableCell>{value.name}</TableCell>
                <TableCell>
                    <TextField value={value.hours} onChange={(event) => this.handleHoursChange(event, part, index)} />
                </TableCell>
            </TableRow>
        })
    }

    private static renderTotalPart(part: CoursePart, target: CoursePart) {
        return part.workloads.map(value =>
            <TableRow key={value.name}>
                <TableCell>{value.name}</TableCell>
                <TableCell style={{ color: (value.hours != target.workloads.find(w => w.name == value.name).hours ? 'red' : 'black') }}>{value.hours}</TableCell>
            </TableRow>
        )
    }

    private static addParts(first: CoursePart, second: CoursePart): CoursePart {
        return {
            workloads: first.workloads.map((e, i) =>
                ({ name: e.name, hours: e.hours + second.workloads[i].hours }))
        }
    }

    private renderSemester = (semester: Semester, parts: CoursePart[]) => {
        let spanCount = parts[0].workloads.length

        let partRows = parts.map((p, partIndex) => this.renderPart(p, partIndex, spanCount))

        let attestationParts = ["Промежуточная аттестация (сам. раб.)", "Консультации", "Промежуточная аттестация"]

        let attestationPart =
            attestationParts.map((wt, index) => {
                const hours = semester.workload.find(w => w.name == wt).hours
                const result =
                    hours == 0
                        ? null
                        : <TableRow key={wt}>
                              {index == 0 ? <TableCell rowSpan={3}>{parts.length + 1}.</TableCell> : null}
                              <TableCell>{wt}</TableCell>
                              <TableCell>{hours}</TableCell>
                          </TableRow>
                return result
            })

        const total = parts.reduce((prev, curr) => CourseStructureEditor.addParts(prev, curr))
        const target = CourseStructureLogic.initPart(semester)

        const result =
            <div key={semester.semester}>
                <h2>Семестр {semester.semester}</h2>
                <Button key="addPart" onClick={() => this.handleAddPartClick(semester)}
                    variant="contained"
                    style={{ margin: '5px 5px' }}>
                    Добавить раздел
                </Button>

                <Button key="autoFill" onClick={() => this.handleAutoFillClick(semester)}
                    variant="contained"
                    style={{ margin: '5px 5px' }}>
                    Заполнить пропорционально
                </Button>

                <TableContainer key="main" component={Paper} style={{ maxWidth: 1000 }}>
                    <Table style={{ tableLayout: 'fixed' }} size="small">
                        <TableHead>
                            <TableRow>
                                <TableCell>№ п/п</TableCell>
                                <TableCell>Вид учебных занятий</TableCell>
                                <TableCell>Количество часов</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {partRows}
                            {attestationPart}
                        </TableBody>
                    </Table>
                </TableContainer>

                <h3>Итого:</h3>
                <TableContainer key="total" component={Paper} style={{ maxWidth: 1000 }}>
                    <Table style={{ tableLayout: 'fixed' }} size="small">
                        <TableHead>
                            <TableRow>
                                <TableCell>Вид учебных занятий</TableCell>
                                <TableCell>Количество часов</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {CourseStructureEditor.renderTotalPart(total, target)}
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>

        return result
    }

    render() {
        if (this.props.courseParts.length == 0) {
            return null
        }

        const result =
            <div>
                <h1>Редактор структуры курса и разбивки по часам:</h1>
                <p>"Заполнить пропорционально" заполняет нулевые поля в нагрузке пропорционально часам первого вида
                нагрузки (обычно это лекции или семинары) исходя из общей нагрузки, положенной по учебному плану.
                Ненулевые поля оно не трогает. Обратите внимание, по умолчанию первый раздел заполняется полной нагрузкой,
                так что эта кнопка ничего не сделает, если не поправить в первом разделе часы! Если и первый вид нагрузки 
                имеет только нули, раскидывает часы поровну между разделами курса.</p>
                <p><b>Иногда ошибается на один-два часа из-за округления, проверяйте соответствие таблицы "Итого" с
                    часами в таблицах выше!</b></p>
                <p>Часы нагрузки по разделам могут редактироваться вручную, суммарная нагрузка пересчитывается в таблице "Итого".</p>
                {this.props.courseParts.map(value => this.renderSemester(value.semester, value.parts))}
            </div>

        return result
    }
}
