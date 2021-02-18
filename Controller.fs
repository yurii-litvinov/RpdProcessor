module RpdProcessor.Controller

open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open Giraffe

open CurriculumUtils
open Model

let findCompetenceDescription (curriculum: Curriculum) code =
    let competences = curriculum.Competences
    competences |> Seq.find (fun c -> c.Name = code) |> fun c -> c.Description

/// Expecting working plan in <programme>_<year> format, for example, "ВМ.5665_2020"
let competencesHandler (plan: string, rpdNum: string) =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let curriculums = loadCurriculums ()
            
            let curriculum = curriculums |> Seq.tryFind (fun c -> $"{c.Programme}_{c.Year}" = plan)

            match curriculum with
            | None -> return! json () next ctx
            | Some c -> 
                let discipline = c.Disciplines |> Seq.tryFind (fun d -> d.Code = rpdNum)
                match discipline with
                | None -> return! json () next ctx
                | Some discipline ->
                    let competences = discipline.Competences
                    let result = 
                        competences
                        |> Seq.map (fun code -> (code, findCompetenceDescription c code))
                        |> Seq.map (fun (code, description) -> {Name = code; Description = description})
                    return! json result next ctx
        }

let hoursHandler (rpdNum: string) =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let curriculums = loadCurriculums ()
           
            let discipline = 
                curriculums 
                |> Seq.map (fun c -> c.Disciplines) 
                |> Seq.concat 
                |> Seq.filter (fun d -> d.Code = rpdNum)
                |> Seq.toList

            let result = 
                discipline
                |> Seq.map (fun d -> 
                    { 
                        Semester = d.Semester 
                        WorkTypes = d.WorkTypes |> Seq.map (fun (name, hours) -> { ItemName = name; Hours = hours})
                    })

            return! json result next ctx
        }

let workPlansHandler (next : HttpFunc) (ctx : HttpContext) =
    task {
        let curriculums = listCurriculums ()
        return! json curriculums next ctx
    }