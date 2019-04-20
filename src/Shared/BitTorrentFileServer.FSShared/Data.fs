namespace BitTorrentFileServer.Data

type Folder =
    { name : string
      folders : Folder list }