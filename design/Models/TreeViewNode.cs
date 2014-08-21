using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace design.Models
{
    public class TreeViewNode
    {
        public string id { get; set; }
        public string text { get; set; }
        public bool expanded { get; set; }
        public string classes { get; set; }
        public bool hasChildren { get; set; }
        public TreeViewNode[] children { get; set; }


        public TreeViewNode(string id, string text)
        {
            this.id = id;
            this.text = text;
        }
    }
}