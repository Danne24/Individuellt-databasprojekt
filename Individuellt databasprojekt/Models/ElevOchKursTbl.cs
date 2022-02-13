using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class ElevOchKursTbl
    {
        public int ElevKursId { get; set; }
        public int? ElevFk { get; set; }
        public int? KursFk { get; set; }

        public virtual ElevTbl ElevFkNavigation { get; set; }
        public virtual KursTbl KursFkNavigation { get; set; }
    }
}
