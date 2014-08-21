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
        static List<TreeViewNode> nodes;
        static DesignController()
        {
            nodes = new List<TreeViewNode>();
            TreeViewNode t1 = new TreeViewNode("1", "Könyv");
            TreeViewNode alt = new TreeViewNode("1a", "Irodalom");
            TreeViewNode b1 = new TreeViewNode("1a1", "Szépirodalom");
            TreeViewNode b2 = new TreeViewNode("1a2", "Szakirodalom");
            TreeViewNode blt = new TreeViewNode("1b", "Krimi");
            alt.children = new TreeViewNode[] { b1,b2  };
            t1.children = new TreeViewNode[] { alt, blt };
            alt.hasChildren = true;
            t1.hasChildren = true;
            nodes.Add(t1);
            nodes.Add(b1);
            nodes.Add(b2);
            nodes.Add(alt);
            nodes.Add(blt);

        }
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileSystemInfos(string root)
        {
            List<TreeViewNode> model = new List<TreeViewNode>();
            if (root == "source" || root == null)
                model = nodes.Where(x =>x.id == "1").ToList();
            else
            {
                model = nodes.SingleOrDefault(x => x.id == root).children.OrderBy(x => x.text).ToList();
            }
            return Json(model.ToArray());
           
        }

    }
}
