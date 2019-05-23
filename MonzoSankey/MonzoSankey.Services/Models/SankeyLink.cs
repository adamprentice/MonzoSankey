using System;
using System.Collections.Generic;
using System.Text;

namespace MonzoSankey.Services.Models
{
    public class SankeyLink
    {
        public SankeyLink(int source, int target, double value)
        {
            this.Source = source;
            this.Target = target;
            this.Value = value;
        } 

        public int Source { get; set; } // index of source in Nodes

        public int Target { get; set; } // index of target in Nodes

        public double Value { get; set; }

        public string Color { get; set; }

        public string Key { get; set; }

        public int? Opacity { get; set; }
    }
}
