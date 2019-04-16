module BitTorrentFileServer.Client.Main

open Elmish
open Bolero
open Bolero.Html
open Bolero.Templating.Client
open System.IO
open System
open BitTorrentFileServer.Data
open BitTorrentFileServer.Functions
open BitTorrentFileServer.Service
open Bolero.Remoting

type Model =
    { value : int
      mutable rootFolder: Folder }

let initModel = { value = 0; rootFolder = {name = ""; folders = []}}

type Message =
    | RequestUpdate
    | UpdateFolder of Folder
    | Error of exn

type FolderTemplate = Template<"wwwroot/folder.html">

let rec getFoldersView isRoot (folder : Folder) : Node =
    match isRoot with
    | true -> FolderTemplate().Name(folder.name).Content(forEach folder.folders (getFoldersView false) ).Elt()
    | false -> FolderTemplate.subFolder().Name(folder.name).Content(forEach folder.folders (getFoldersView false) ).Elt()


let update webService message model =
    match message with
    | RequestUpdate -> 
           model, 
           Cmd.ofAsync 
                webService.getFolders ()
                (fun folder -> (UpdateFolder folder))
                Error
    | UpdateFolder folder -> { model with rootFolder = folder }, []
    | Error exn -> model, []

type Button = Template<"wwwroot/button.html">

let view model dispatch =
    concat [ Button().Text("Update").Click(fun _ -> dispatch RequestUpdate).Elt()
             getFoldersView true model.rootFolder ]

type FileServerApp() =
    inherit ProgramComponent<Model, Message>()
    override this.Program =
        let webService = this.Remote<WebService>()
        Program.mkProgram (fun _ -> initModel, []) (update webService) view
#if DEBUG

        |> Program.withHotReloading
#endif
