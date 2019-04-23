namespace BitTorrentFileServer

open System.IO
open BitTorrentFileServer.Data

module Functions =
    let rec getFolderByDirectoryWithName (n : string) (dir : DirectoryInfo) : Folder =
        { name =
              match n with
              | null -> dir.Name
              | _ -> n
          folders =
              (dir.GetDirectories()
               |> Array.toList
               |> List.map (fun d -> getFolderByDirectoryWithName null d)) }

    let getFolderByDirectory = getFolderByDirectoryWithName null

    let getContentByDirectory (dir : DirectoryInfo) : Element list =
        List.append (dir.GetDirectories()
                     |> Array.toList
                     |> List.map (fun d ->
                            { name = d.Name
                              isFolder = true })) (dir.GetFiles()
                                                   |> Array.toList
                                                   |> List.map (fun f ->
                                                          { name = f.Name
                                                            isFolder = false }))
