using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class BetygTbl
    {
        public BetygTbl()
        {
            BetygOchElevTbl = new HashSet<BetygOchElevTbl>();
            BetygOchKursTbl = new HashSet<BetygOchKursTbl>();
            BetygOchPersonalTbl = new HashSet<BetygOchPersonalTbl>();
        }

        public int BetygId { get; set; }
        public int? BetygNamnFk { get; set; }
        public DateTime? Betygsdatum { get; set; }

        public virtual BetygNamnTbl BetygNamnFkNavigation { get; set; }
        public virtual ICollection<BetygOchElevTbl> BetygOchElevTbl { get; set; }
        public virtual ICollection<BetygOchKursTbl> BetygOchKursTbl { get; set; }
        public virtual ICollection<BetygOchPersonalTbl> BetygOchPersonalTbl { get; set; }
    }
}
