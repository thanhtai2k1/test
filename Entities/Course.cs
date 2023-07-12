using System;
using System.Collections.Generic;

namespace QLSV.Entities
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
        }

        public int Courseid { get; set; }
        public string Coursename { get; set; } = null!;

        public virtual ICollection<Class> Classes { get; set; }
    }
}
