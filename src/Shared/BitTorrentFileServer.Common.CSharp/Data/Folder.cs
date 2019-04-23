using BitTorrentFileServer.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitTorrentFileServer.Common.CSharp.Data
{
    public class Folder
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("content")]
        public List<Element> Content { get; set; }
    }
}