namespace BitTorrentFileServer

open System.IO
open BitTorrentFileServer.Data

module Functions =
    let rec getFolderByDirectoryWithName (n : string) (dir : DirectoryInfo) : Folder =
        { name = match n with 
                    | null -> dir.Name
                    | _ -> n
          folders =
              (dir.GetDirectories()
               |> Array.toList
               |> List.map (fun d -> getFolderByDirectoryWithName null d)) }

    let getFolderByDirectory = getFolderByDirectoryWithName null
    
    let getFoldersByDirectory (dir : DirectoryInfo) : string list = 
        dir.GetDirectories()
        |> Array.toList
        |> List.map (fun d -> d.Name)