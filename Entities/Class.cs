using System;
using System.Collections.Generic;

namespace QLSV.Entities
{
    public partial class Class
    {
        public Class()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Classid { get; set; }
        public string Classname { get; set; } = null!;
        public int? Courseid { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
