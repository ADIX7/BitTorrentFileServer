using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BitTorrentFileServer.Common.CSharp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitTorrentFileServer.Vue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        [HttpGet]
        [HttpGet("{path}")]
        public ActionResult<Folder> Get(string path = null)
        {
            string finalPath = ".";
            try
            {
                var parsedPath = System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(path));

                if (Directory.Exists("wwwroot/testData/" + parsedPath))
                    finalPath = parsedPath ?? finalPath;
            }
            catch { }

            finalPath = finalPath.TrimEnd('/');

            var content = Functions.getContentByDirectory(new DirectoryInfo("wwwroot/testData/" + finalPath)).ToList();

            var folder = new Folder() { Path = finalPath, Content = content };

            return folder;
        }
    }
}