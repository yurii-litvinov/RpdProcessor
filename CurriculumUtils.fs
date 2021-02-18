module RpdProcessor.CurriculumUtils

open System.Text.RegularExpressions
open System.IO

open CurriculumParser
open Model

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
            "Под руководством преподавателя"
            "В присутствии преподавателя"
            "В т.ч. с использованием учебно-методич. материалов"
            "Текущий контроль"
            "Промежуточная аттестация"
            "Объём занятий в активных и интерактивных формах, часов"
        ] 

    let getWorkTypes (impl: DisciplineImplementation) =
        let workHours = impl.WorkHours.Split [|' '|] |> Seq.map int

        Seq.zip workTypes workHours |> Seq.filter (fun wt -> snd wt > 0) |> Seq.toList

    let parseImplementations (impl: DisciplineImplementation) =
        {
            Semester = impl.Semester
            Code = impl.Discipline.Code
            Name = impl.Discipline.RussianName 
            LaborIntensity = impl.LaborIntensity
            Competences = impl.Competences |> Seq.map (fun (c: CurriculumParser.Competence) -> c.Code)
            AttestationType = impl.MonitoringTypes
            WorkTypes = getWorkTypes impl
        }

    let parseDiscipline (discipline: CurriculumParser.Discipline) =
        discipline.Implementations
        |> Seq.map parseImplementations

    member _.Disciplines =
        curriculum.Disciplines
        |> Seq.map parseDiscipline
        |> Seq.concat

    member _.Competences = 
        curriculum.Competences
        |> Seq.map (fun c -> { Name = c.Code; Description = c.Description })

    member _.Programme = programme

    member _.Year = year

let loadCurriculums () =
    System.IO.Directory.GetFiles("WorkingPlans", "*.docx")
    |> Seq.map (fun file -> Curriculum(file))

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
