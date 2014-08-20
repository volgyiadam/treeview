using design.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace design.Controllers
{
    public class DesignController : Controller
    {
        //
        // GET: /Design/
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileSystemInfos(string root)
        {
            DirectoryInfo rootDirectory = null;
            if (root == null || root=="source")
                rootDirectory = new DirectoryInfo(@"C:\dev\");
            else
            {
                rootDirectory = new DirectoryInfo(root);

            }
            var directoryChildren = from child in rootDirectory.GetFileSystemInfos()
                                    orderby child is DirectoryInfo descending
                                    select child;

            List<TreeViewNode> nodes = new List<TreeViewNode>();
            foreach (FileSystemInfo directoryChild in directoryChildren)
            {
                bool isDirectory = directoryChild is DirectoryInfo;
                nodes.Add(new TreeViewNode()
                {
                    id = directoryChild.FullName,
                    text = directoryChild.Name,
                    classes = isDirectory ? "folder" : "file",
                    hasChildren = isDirectory
                    
                    
                });
            }
            return Json(nodes.ToArray());
            //return new JsonResult() { Data = nodes.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

    }
}
