using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore3._0Mvc.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public int Rate { get; set; }
        public string Company { get; set; }
        public string Producer { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
