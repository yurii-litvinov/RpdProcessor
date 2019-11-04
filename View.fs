module RpdProcessor.View

open Giraffe
open Model
open Newtonsoft.Json

module Views =
    open GiraffeViewEngine

    let magicFunction = "showSelectedCompetences()"

    let interpretHours = "interpretHours()"

    let serializeModel (model : Model) =
        JsonConvert.SerializeObject(model)

    let formatCompetence (competence: Competence) =
        let description = competence.Description
        let correctedDescription = description.[0].ToString().ToLower() + (description.Substring 1)
        competence.Name + " – " + correctedDescription + ";"

    let wrapAndSelect id (data: string seq) =
        Seq.map encodedText data
        |> Seq.map (fun node -> option [] [node]) |> Seq.toList
        |> select [_id id; _oninput magicFunction ]

    let layout (model : Model) (content: XmlNode list) =
        html [] [
            head [] [
                title []  [ encodedText "RpdProcessor" ]
                link [ _rel  "stylesheet"
                       _type "text/css"
                       _href "/main.css" ]
                script [_type "application/javascript"
                        _src "/scripts.js"] []
                script [_type "application/javascript"] 
                       [ rawText <| "var viewModel = " + (serializeModel model)]
            ]
            body [KeyValue("onload", "document.getElementById('plans').selectedIndex = 3;\n" + magicFunction)] content
        ]

    let hoursInterpreter () =
        div [] [
            h1 [] [ encodedText "Толкователь часов из учебного плана" ]
            p [] [textarea [_id "hours"; _type "text"; KeyValue("onchange", interpretHours)] []]
            div [_id "hoursDiv"] []
        ]

    let competenceGenerator (model: Model) =
        div [] [
            h1 [] [ encodedText "Генерилка компетенций" ]
            p [] [wrapAndSelect "plans" (model.Plans |> Seq.map (fun p -> p.Key))]
            p [] [wrapAndSelect "years" ["2016"; "2017"; "2018"; "2019"]]
            p [] [input [_id "competences"; _type "text"; KeyValue("onchange", magicFunction)]]
            p [] [
                for plan in model.Plans ->
                    div [_id plan.Key] ((h2 [] [str plan.Key]) ::
                        [
                            for year in model.Plans.[plan.Key] ->
                                div [_id (plan.Key + "_" + year.Year)] ((h3 [] [str year.Year]) ::
                                    [
                                        for competence in year.Competences ->
                                            div [_id (plan.Key + "_" + year.Year + "_" + competence.Name)] 
                                              [str <| formatCompetence competence ]
                                    ])
                        ])
            ]
        ]

    let index (model : Model) =
        [
            hoursInterpreter ()
            competenceGenerator model
        ] |> layout model