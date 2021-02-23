/// Serves initial HTML page with links to required scripts and resources.
module RpdProcessor.View

open Giraffe
open Newtonsoft.Json

open DataContract

/// Module with HTML generating functions.
module Views =
    open GiraffeViewEngine

    /// Provides general layout for index page, includes working plans list.
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

    /// Provides index page.
    let index model =
        [
            div [_id "root"] []
        ] |> layout model
