using System;
using System.Collections.Generic;
using System.Text;

namespace MonzoApi.Services.Models
{
    public class Pagination
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public int? Limit { get; set; }
    }
}
