using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public class Match : BaseDomainModel
    {
        public int HomeTeamId
        {
            get;
            set;
        }

        public int HomeTeamScore
        {
            get;
            set;
        }

        public int AwayTeamId
        {
            get;
            set;
        }

        public int AwayTeamScore
        {
            get;
            set;
        }

        public decimal TicketPrice
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public virtual Team HomeTeam
        {
            get;
            set;
        }

        public virtual Team AwayTeam
        {
            get;
            set;
        }
    }
}
