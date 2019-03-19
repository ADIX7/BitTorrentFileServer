namespace BitTorrentFileServer.Service

open BitTorrentFileServer.Data
open Bolero.Remoting

type WebService =
    {
        getFolders : unit -> Async<Folder>
    }
    
    interface IRemoteService with
        member this.BasePath = "/api"