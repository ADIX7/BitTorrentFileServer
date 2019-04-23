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

        /* 

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        } */
    }
}