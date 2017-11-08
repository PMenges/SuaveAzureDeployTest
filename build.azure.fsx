#r "packages/Suave/lib/net40/Suave.dll"
#r "packages/FAKE/tools/FakeLib.dll"

#load "app.fsx"
open App
open Fake

open System
open System.Net
open System.Threading.Tasks
open System.IO

open Suave
open Suave.Web
open Suave.Successful
open Suave.Http
open Suave.Operators
open Suave.Filters

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

let serverConfig =
    let port = Sockets.Port.Parse <| getBuildParamOrDefault "port" "8083"
    { defaultConfig with
        homeFolder = Some __SOURCE_DIRECTORY__
        bindings = [ HttpBinding.create HTTP IPAddress.Loopback port ] }

startWebServer serverConfig app
 