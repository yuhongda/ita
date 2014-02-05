using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITA.Model
{
    public class Work
    {
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int ProjectID { get; set; }
    }
}
