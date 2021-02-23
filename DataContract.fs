/// Provides classes that act as JSON-serializable data transfer objects for frontend.
module RpdProcessor.DataContract

open Newtonsoft.Json

/// Information about working plans (or curriculums).
type PlanInfo = 
    {
        /// Name of a plan, for example, "СВ.5006".
        [<JsonProperty("name")>]
        Name: string

        /// Year of admission of a plan, for example, "2020".
        [<JsonProperty("year")>]
        Year: string
    }

/// Information about a competence.
type Competence =
    {
        /// Competence code, for example, "ОПК-2".
        [<JsonProperty("code")>]
        Code: string

        /// Competence description, for example, "способен применять современный математический аппарат..."
        [<JsonProperty("description")>]
        Description: string
    }

/// Information about workload item for a given semester.
type WorkloadItem =
    {
        /// Name of an item, for example, "Лекции". Full list of possible workload item names 
        /// is provided in CurriculumUtils.fs.
        [<JsonProperty("name")>]
        Name: string

        /// Hours of work, for example, "30".
        [<JsonProperty("hours")>]
        Hours: int
    }

/// Information about one semester of a discipline. Most disciplines are single semester, but some span multiple 
// semesters, like Programming or Mathematical Analysis.
type DisciplineSemester =
    {
        /// Number of semester in which the discipline is implemented, from 1 to 8.
        [<JsonProperty("semester")>]
        Semester: int

        /// Labor intensity of a semester, in ECTS credits.
        [<JsonProperty("laborIntensity")>]
        LaborIntensity: int

        /// Type of an attestation, can be "зачёт" or "экзамен".
        [<JsonProperty("attestationType")>]
        AttestationType: string

        /// A list of workload items with non-zero hours of work.
        [<JsonProperty("workload")>]
        Workload: WorkloadItem list
    }

/// Information about discipline.
type Discipline =
    {
        /// Code of a working program, for example, "002212".
        [<JsonProperty("code")>]
        Code: string

        /// Russian name of a discipline.
        [<JsonProperty("name")>]
        Name: string

        /// A list of competences improved by this discipline.
        [<JsonProperty("competences")>]
        Competences: Competence list

        /// A list of semesters in which the discipline is implemented, with semester-specific info.
        [<JsonProperty("semesters")>]
        Semesters: DisciplineSemester list
    }
