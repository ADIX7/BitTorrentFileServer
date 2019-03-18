namespace BitTorrentFileServer.Server

open BitTorrentFileServer.Data
open Bolero.Remoting

type WebService =
    {
        getFolders : Async<option<Folder>>
    }
    
    interface IRemoteService with
        member this.BasePath = "/api"