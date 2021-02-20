import { Button, ButtonGroup, PropTypes } from '@material-ui/core'
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
            let plans = this.props.plans.map((plan) => {
                let color: PropTypes.Color = plan == this.props.selectedPlan ? "secondary" : "default"
                return <Button
                    color={color}
                    key={Utils.planInfoToString(plan)}
                    onClick={() => this.handleButtonClick(plan)}
                >
                    {Utils.planInfoToString(plan)}
                </Button>
            })

            const result =
                <div>
                    <h1>Выберите учебный план:</h1>
                    <ButtonGroup
                        id="plansGroup"
                        orientation="vertical"
                        color="primary"
                        size="large"
                    >
                        {plans}
                    </ButtonGroup>
                </div>
            return result
        }
    }
}
