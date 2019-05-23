using System;
using System.Collections.Generic;
using System.Text;

namespace MonzoSankey.Services.Models
{
    public class SankeyNode
    {
        public SankeyNode (string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string Color { get; set; }

        public int? Opacity { get; set; }

        public string Key { get; set; }
    }
}
