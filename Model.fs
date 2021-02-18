module RpdProcessor.Model

type Discipline =
    {
        Semester: int
        Code: string
        Name: string
        LaborIntensity: int
        Competences: string seq
        AttestationType: string
        WorkTypes: (string * int) seq
    }

type Competence =
    {
        Name: string
        Description: string
    }

type PlanInfo = 
    {
        Name: string
        Year: string
    }

type WorkloadItem =
    {
        ItemName: string
        Hours: int
    }

type WorkTypesInfo =
    {
        Semester: int
        WorkTypes: WorkloadItem seq
    }
