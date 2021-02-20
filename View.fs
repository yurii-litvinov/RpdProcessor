module RpdProcessor.View

open Giraffe
open Newtonsoft.Json

open DataContract

module Views =
    open GiraffeViewEngine

    let layout (model: PlanInfo seq) (content: XmlNode list) =
        html [] [
            head [] [
                title []  [ encodedText "RpdProcessor" ]
                link [ _rel "stylesheet"
                       _type "text/css"
                       _href "/main.css" ]
                link [ _rel "stylesheet"
                       _href "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" ]
                script [_src "bundle.js"] []
                script [_type "application/javascript"] 
                       [ rawText <| "var plansList = " + (JsonConvert.SerializeObject model)]
            ]
            body [
                attr "onload" "Scripts.render()"
            ] content
        ]

    let index model =
        [
            div [_id "root"] []
        ] |> layout model
