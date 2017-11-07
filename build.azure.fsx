#r "packages/Suave/lib/net40/Suave.dll"
#r "packages/FAKE/tools/FakeLib.dll"
#load "app.fsx"
open App
open Fake

open System
open System.Net
open System.IO
open Suave
open Suave.Web
open Suave.Successful
open Suave.Http


let serverConfig =
    let port = Sockets.Port.Parse (getBuildParam "port")
    { defaultConfig with
        homeFolder = Some __SOURCE_DIRECTORY__
        bindings = [ HttpBinding.create HTTP IPAddress.Loopback port ] }

Target "run" (fun _ ->
    startWebServer serverConfig app
)

RunTargetOrDefault "run"
