using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estudent.Models
{
    public class InfoBoxViewData
    {
        public Student selectedStudent { get; set; }
        public List<Ispit> passedExams { get; set; }
        public string avg { get; set; }

    }
}