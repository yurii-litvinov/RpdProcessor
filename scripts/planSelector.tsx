import { Button, ButtonGroup, Paper, PropTypes, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core'
import * as React from 'react'
import { PlanInfo } from './model'
import { Utils } from './utils'

type PlanSelectorProps = {
    plans: PlanInfo[]
    selectedPlan: PlanInfo
    onSelectedChanged: (plan: PlanInfo) => void
}

export class PlanSelector extends React.Component<PlanSelectorProps> {
    private handleButtonClick = (plan: PlanInfo) => {
        this.props.onSelectedChanged(plan)
    }

    render(): JSX.Element {
        if (this.props.plans == []) {
            return <p>Загрузка учебных планов...</p>
        } else {
            let groupedPlans = this.props.plans.reduce((acc: Map<string, PlanInfo[]>, plan: PlanInfo, _: number) => {
                if (!acc.has(plan.name)) {
                    acc.set(plan.name, [])
                }

                acc.get(plan.name).push(plan)
                return acc
            }, new Map<string, PlanInfo[]>())


            let tableHeadCells = []
            for (let key of groupedPlans.keys()) {
                tableHeadCells.push(
                    <TableCell key={key} align="center" style={{ borderWidth: 1, borderColor: 'grey', borderStyle: 'solid' }}>
                        {key}
                    </TableCell>)
            }

            let tableButtons = []
            for (let key of groupedPlans.keys()) {
                let column = []
                for (let plan of groupedPlans.get(key).sort((a: PlanInfo, b: PlanInfo) => a.year > b.year ? -1 : 1)) {
                    let color: PropTypes.Color = plan == this.props.selectedPlan ? "secondary" : "default"
                    column.push(
                        <Button
                            color={color}
                            key={Utils.planInfoToString(plan)}
                            onClick={() => this.handleButtonClick(plan)}
                            variant="outlined"
                            style={{ margin: '5px 5px' }}
                        >
                            {Utils.planInfoToString(plan)}
                        </Button >)
                }
                tableButtons.push(column)
            }

            const result =
                <div>
                    <h1>Выберите учебный план:</h1>
                    <TableContainer component={Paper} style={{ maxWidth: 1000 }}>
                        <Table style={{ tableLayout: 'fixed' }}>
                            <TableHead>
                                <TableRow>
                                    {tableHeadCells}
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                <TableRow>
                                    {tableButtons.map((c, i) =>
                                        <TableCell key={i} align="center" style={{ borderWidth: 1, borderColor: 'grey', borderStyle: 'solid' }}>
                                            {c}
                                        </TableCell>)}
                                </TableRow>
                            </TableBody>
                        </Table>
                    </TableContainer>
                </div>

            return result
        }
    }
}
