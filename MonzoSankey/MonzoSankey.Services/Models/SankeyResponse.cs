using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonzoSankey.Services.Models
{
    public class SankeyResponse
    {
        public SankeyResponse(IEnumerable<SankeyNode> nodes, IEnumerable<SankeyLink> links)
        {
            this.Nodes = nodes.ToArray();
            this.Links = links.ToArray();
        }
        public SankeyNode[] Nodes { get; set; }

        public SankeyLink[] Links { get; set; }
    }
}
