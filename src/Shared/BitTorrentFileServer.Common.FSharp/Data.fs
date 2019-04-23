namespace BitTorrentFileServer.Data

type Folder =
    { name : string
      folders : Folder list }

type Element =
    { name: string
      isFolder: bool }