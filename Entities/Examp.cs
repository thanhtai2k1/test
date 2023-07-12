using System;
using System.Collections.Generic;

namespace QLSV.Entities
{
    public partial class Examp
    {
        public int Examid { get; set; }
        public string Examname { get; set; } = null!;
        public double Examps { get; set; }
        public string Ranks { get; set; } = null!;
        public int? Studentid { get; set; }

        public virtual Student? Student { get; set; }
    }
}
