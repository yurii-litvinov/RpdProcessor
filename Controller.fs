module RpdProcessor.Controller

open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open Giraffe

open CurriculumUtils
open View

/// Serves HTML with scripts and initial data, consisting of plans information.
let indexHandler: HttpFunc -> HttpContext -> HttpFuncResult =
    let curriculums = listCurriculums ()
    let view = Views.index curriculums
    htmlView view

/// Provides information about discipline and its implementations by semester.
/// Expecting working plan in <programme>-<year> format, for example, "ВМ.5665_2020"
let disciplineInfoHandler (plan: string, rpdNum: string) =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let curriculum = loadCurriculum plan
            
            match curriculum with
            | None -> return! json () next ctx
            | Some c -> 
                let discipline = c.Disciplines |> Seq.tryFind (fun d -> d.Code = rpdNum)
                match discipline with
                | None -> return! json () next ctx
                | Some discipline ->
                    return! json discipline next ctx
        }

/// Returns JSON with information about loaded plans (array PlanInfo objects).
let listCurriculumsHandler (next : HttpFunc) (ctx : HttpContext) =
    task {
        let curriculums = listCurriculums ()
        return! json curriculums next ctx
    }