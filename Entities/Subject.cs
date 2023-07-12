using System;
using System.Collections.Generic;

namespace QLSV.Entities
{
    public partial class Subject
    {
        public Subject()
        {
            Students = new HashSet<Student>();
        }

        public int Subjectid { get; set; }
        public string Subjectname { get; set; } = null!;
        public int? Classid { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
