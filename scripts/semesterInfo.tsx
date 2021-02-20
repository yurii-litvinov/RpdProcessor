import { makeStyles, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@material-ui/core"
import * as React from "react"
import { Semester } from "./model"

type SemesterInfoProps = {
    semester: Semester
}

export class SemesterInfo extends React.Component<SemesterInfoProps> {
    render() {
        let semester = this.props.semester 
        if (semester == null) {
            return null
        }

        let filteredWorkload = semester.workload.filter((w) => w.hours != 0)

        return <div>
            <h2>Семестр {semester.semester}</h2>
            <p>Трудоёмкость: <b>{semester.laborIntensity}</b></p>
            <p>Вид аттестации: <b>{semester.attestationType}</b></p>
            <p>Нагрузка:</p>
            <TableContainer component={Paper} style={{ maxWidth: 600 }}>
                <Table size="small" padding="none">
                    <TableHead>
                        <TableRow>
                            <TableCell>Вид нагрузки</TableCell>
                            <TableCell align="right">Часы</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {filteredWorkload.map((w) => 
                            <TableRow key={w.name}>
                                <TableCell>{w.name}</TableCell>
                                <TableCell align="right">{w.hours}</TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    }
}
