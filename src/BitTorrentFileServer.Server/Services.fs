open System.IO
open BitTorrentFileServer.Functions

let WebSerivce = 
    { 
        getFolders = async {
            return getFolderByDirectory(DirectoryInfo("testData"))
        }
    }
