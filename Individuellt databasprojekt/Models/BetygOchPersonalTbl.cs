using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class BetygOchPersonalTbl
    {
        public int BetygOchPersonalId { get; set; }
        public int? BetygOchPersonalBetygFk { get; set; }
        public int? BetygOchPersonalPersonalFk { get; set; }

        public virtual BetygTbl BetygOchPersonalBetygFkNavigation { get; set; }
        public virtual PersonalTbl BetygOchPersonalPersonalFkNavigation { get; set; }
    }
}
