module RpdProcessor.View

open Giraffe

module Views =
    open GiraffeViewEngine

    let layout (content: XmlNode list) =
        html [] [
            head [] [
                title []  [ encodedText "RpdProcessor" ]
                link [ _rel "stylesheet"
                       _type "text/css"
                       _href "/main.css" ]
                link [ _rel "stylesheet"
                       _href "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" ]
                script [_src "bundle.js"] []
            ]
            body [
                attr "onload" "Scripts.render()"
            ] content
        ]

    let index () =
        [
            div [_id "root"] []
        ] |> layout
