namespace BitTorrentFileServer

open System.IO
open BitTorrentFileServer.Data

module Functions =
    let rec getFolderByDirectory (dir : DirectoryInfo) : Folder =
        { name = dir.Name
          folders =
              (dir.GetDirectories()
               |> Array.toList
               |> List.map (getFolderByDirectory)) }
