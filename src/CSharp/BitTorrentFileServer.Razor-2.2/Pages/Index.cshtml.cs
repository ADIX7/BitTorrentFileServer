using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BitTorrentFileServer.Razor_2._2.Pages
{
    public class IndexModel : PageModel
    {
        public string CurrentPath { get; set; } = "./1/a";
        public IEnumerable<string> PathParts
        {
            get
            {
                return CurrentPath.Split('/');
            }
        }

        public List<string> FolderNames { get; set; } = new List<string>();

        public void OnGet()
        {
        }

        public void NavigatoToFolderIndex(int index)
        {
            CurrentPath = Path.Combine(PathParts.ToList().GetRange(0, index).ToArray());
        }

        public void OnGetOpen(int index)
        {
            ;
            NavigatoToFolderIndex(index);
        }

        public void OnPostOpen(int index)
        {
            ;
        }
    }
}
