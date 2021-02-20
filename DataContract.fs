/// Provides classes that act as JSON-serializable data transfer objects for frontend.
module RpdProcessor.DataContract

open Newtonsoft.Json

type PlanInfo = 
    {
        [<JsonProperty("name")>]
        Name: string

        [<JsonProperty("year")>]
        Year: string
    }

type Competence =
    {
        [<JsonProperty("code")>]
        Code: string

        [<JsonProperty("description")>]
        Description: string
    }

type WorkloadItem =
    {
        [<JsonProperty("name")>]
        Name: string

        [<JsonProperty("hours")>]
        Hours: int
    }

type DisciplineSemester =
    {
        [<JsonProperty("semester")>]
        Semester: int

        [<JsonProperty("laborIntensity")>]
        LaborIntensity: int

        [<JsonProperty("attestationType")>]
        AttestationType: string

        [<JsonProperty("workload")>]
        Workload: WorkloadItem list
    }

type Discipline =
    {
        [<JsonProperty("code")>]
        Code: string

        [<JsonProperty("name")>]
        Name: string

        [<JsonProperty("competences")>]
        Competences: Competence list

        [<JsonProperty("semesters")>]
        Semesters: DisciplineSemester list
    }
