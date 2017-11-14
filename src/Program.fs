namespace TestDeploy

module Main =
    open Suave
    open Suave.Web
    open Suave.Filters
    open Suave.Operators
    open Suave.Successful
    open Suave.RequestErrors
    open Suave.Files
    
    open System
    open System.Threading.Tasks
    open System.Net

    [<EntryPoint>]
    let main [|port|] =
    
        let app = 
                choose [
                    GET >=> path "/" >=> OK "Suave test deploy successful! :) "
                    ]


        let customConfig = { defaultConfig with bindings = [ HttpBinding.create HTTP IPAddress.Loopback (uint16 port) ]}

        startWebServer customConfig app
   
        0 // Include integer as exit code