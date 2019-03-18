module BitTorrentFileServer.Client.Main

open Elmish
open Bolero
open Bolero.Html
open Bolero.Templating.Client
open System.IO
open System
open BitTorrentFileServer.Data
open BitTorrentFileServer.Functions
open Bolero.Remoting.Client

type Model =
    { value : int
      mutable rootFolder: DirectoryInfo }

let initModel = { value = 0; rootFolder = DirectoryInfo(".") }

type Message =
    | Increment
    | Decrement

type FolderTemplate = Template<"wwwroot/folder.html">

let rec getFoldersView isRoot (folder : Folder) : Node =
    match isRoot with
    | true -> FolderTemplate().Name(folder.name).Content(forEach folder.folders (getFoldersView false) ).Elt()
    | false -> FolderTemplate.subFolder().Name(folder.name).Content(forEach folder.folders (getFoldersView false) ).Elt()


let update webService message model =
    match message with
    | Increment -> { model with value = model.value + 1 }
    | Decrement -> { model with value = model.value - 1 }

type Button = Template<"wwwroot/button.html">

let view model dispatch =
    concat [ Button().Text("-").Click(fun _ -> dispatch Decrement).Elt()
             span [] [ textf " %i " model.value ]
             Button().Text("+").Click(fun _ -> dispatch Increment).Elt()
             getFoldersView true (getFolderByDirectory model.rootFolder) ]

type FileServerApp() =
    inherit ProgramComponent<Model, Message>()
    override this.Program =
        let webService = this.Remote<WebSerivce>()
        Program.mkSimple (fun _ -> initModel) (update webService) view
#if DEBUG

        |> Program.withHotReloading
#endif
