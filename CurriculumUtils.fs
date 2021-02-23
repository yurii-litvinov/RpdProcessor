/// Wrapper around CurriculumParser, provides parsing of workload items, supports listing and loading of plans.
module RpdProcessor.CurriculumUtils

open System.Text.RegularExpressions
open System.IO

open CurriculumParser
open DataContract

/// Wrapper around CurriculumParser, provides info about single working plan.
type Curriculum(fileName: string) =
    let curriculum = DocxCurriculum(fileName)

    let programme = FileInfo(fileName).Name.Substring(0, "ВМ.5665".Length)
    let year = FileInfo(fileName).Name.Substring("ВМ.5665-".Length, 4)

    let workTypes = 
        [
            "Лекции"
            "Семинары"
            "Консультации"
            "Практические занятия"
            "Лабораторные работы"
            "Контрольные работы"
            "Коллоквиумы"
            "Текущий контроль"
            "Промежуточная аттестация"
            "Под руководством преподавателя (сам. раб.)"
            "В присутствии преподавателя (сам. раб.)"
            "В т.ч. с использованием учебно-методич. материалов (сам. раб.)"
            "Текущий контроль (сам. раб.)"
            "Промежуточная аттестация (сам. раб.)"
            "Объём занятий в активных и интерактивных формах, часов"
        ] 

    let getWorkTypes (impl: DisciplineImplementation) =
        let workHours = impl.WorkHours.Split [|' '|] |> Seq.map int

        Seq.zip workTypes workHours 
        |> Seq.filter ((<=) 0 << snd) 
        |> Seq.map (fun (t, h) -> {Name = t; Hours = h})
        |> Seq.toList

    let parseImplementations (impl: DisciplineImplementation) =
        {
            Semester = impl.Semester
            LaborIntensity = impl.LaborIntensity
            AttestationType = impl.MonitoringTypes
            Workload = getWorkTypes impl
        }

    let competences (discipline: CurriculumParser.Discipline) =
        discipline.Implementations.[0].Competences
        |> Seq.map (fun c -> {Code = c.Code; Description = c.Description})
        |> Seq.toList

    let parseDiscipline (discipline: CurriculumParser.Discipline) =
        let semesters = 
            discipline.Implementations
            |> Seq.map parseImplementations
            |> Seq.toList

        { 
            Code = discipline.Code
            Name = discipline.RussianName
            Competences = competences discipline
            Semesters = semesters
        }

    /// List of all disciplines in this plan.
    member _.Disciplines =
        curriculum.Disciplines
        |> Seq.map parseDiscipline

    /// Programme name, for example, "СВ.5006".
    member _.Programme = programme

    /// Year of admission of a plan, for example, "2019".
    member _.Year = year

/// Loads a plan with given name. Plan name is expected in format"{programme name}-{year}", for example, "СВ.5162-2020".
let loadCurriculum (name: string) =
    if File.Exists $"WorkingPlans/{name}.docx" then
        Some(Curriculum($"WorkingPlans/{name}.docx"))
    else
        None

/// Returns a list of available working plan names as a sequence of PlanInfo objects.
let listCurriculums () =
    let parseFileName fileName = 
        let matches = Regex.Match(fileName, @"(..\.\d{4})-(\d{4})")
        match matches.Success with
        | false -> None
        | true -> 
            let programme = matches.Groups.[1].Value
            let year = matches.Groups.[2].Value
            Some {Name = programme; Year = year}

    System.IO.Directory.GetFiles("WorkingPlans", "*.docx")
    |> Seq.map parseFileName
    |> Seq.choose id
