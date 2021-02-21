import { CircularProgress, Grid, TextField } from "@material-ui/core"
import * as React from "react"
import { ApiStatus } from "./utils"

type Props = {
    onDisciplineCodeChanged: (disciplineCode: string) => void
    apiStatus: ApiStatus
}

type State = {
    currentCode: string
} 

export class DisciplineCodeInput extends React.Component<Props, State> {
    state: State = { currentCode: "" }

    private handleChange = (event: any) => {
        let code = event.target.value
        this.props.onDisciplineCodeChanged(code)
        this.setState({ currentCode: code })
    }

    render() {
        let result =
            <div>
                <h1>Номер РПД:</h1>
                <p>Сюда введите числовой код РПД, например, "002212" (сработает для СВ.5006.* и СВ.5162.*)</p>
                {this.props.apiStatus == ApiStatus.Ok
                    ? <TextField variant="outlined" label="Код РПД" onChange={this.handleChange} defaultValue={this.state.currentCode} />
                    : this.props.apiStatus == ApiStatus.DisciplineNotFound
                        ? <TextField variant="outlined" label="Код РПД" error helperText="РПД не найдена" onChange={this.handleChange} defaultValue={this.state.currentCode} />
                        : <Grid container alignItems="center" alignContent="flex-start" spacing={2}>
                            <Grid item>
                                <TextField variant="outlined" label="Код РПД" onChange={this.handleChange} defaultValue={this.state.currentCode} />
                            </Grid>
                            <Grid item>
                                <CircularProgress />
                            </Grid>
                        </Grid>
                }
            </div>

        return result
    }
}
