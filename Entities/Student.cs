using System;
using System.Collections.Generic;

namespace QLSV.Entities
{
    public partial class Student
    {
        public Student()
        {
            Examps = new HashSet<Examp>();
        }

        public int Studentid { get; set; }
        public string Studenname { get; set; } = null!;
        public string Loginname { get; set; } = null!;
        public string Passwords { get; set; } = null!;
        public string Andress { get; set; } = null!;
        public int? Subjectid { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Examp> Examps { get; set; }
    }
}
