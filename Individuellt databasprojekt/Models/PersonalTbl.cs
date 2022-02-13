using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class PersonalTbl
    {
        public PersonalTbl()
        {
            BetygOchPersonalTbl = new HashSet<BetygOchPersonalTbl>();
        }

        public int PersonalId { get; set; }
        public string PersonalFörnamn { get; set; }
        public string PersonalEfternamn { get; set; }
        public string PersonalKön { get; set; }
        public int? PersonalYrkesrollFk { get; set; }
        public DateTime? PersonalBörjadeJobbaDatum { get; set; }
        public string PersonalTillhörAvdelning { get; set; }
        public decimal? PersonalMånadslön { get; set; }

        public virtual PersonalYrkesrollTbl PersonalYrkesrollFkNavigation { get; set; }
        public virtual ICollection<BetygOchPersonalTbl> BetygOchPersonalTbl { get; set; }
    }
}
