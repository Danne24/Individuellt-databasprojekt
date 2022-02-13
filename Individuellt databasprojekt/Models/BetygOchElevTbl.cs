using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class BetygOchElevTbl
    {
        public int BetygOchElevId { get; set; }
        public int? BetygOchElevBetygFk { get; set; }
        public int? BetygOchElevBetygElevFk { get; set; }

        public virtual ElevTbl BetygOchElevBetygElevFkNavigation { get; set; }
        public virtual BetygTbl BetygOchElevBetygFkNavigation { get; set; }
    }
}
