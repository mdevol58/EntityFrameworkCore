using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public class Team : BaseDomainModel
    {
        public string? Name
        {
            get;
            set;
        }

        public int? LeagueId
        {
            get;
            set;
        }

        public int CoachId
        {
            get;
            set;
        }

        public virtual League? League
        {
            get;
            set;
        }

        public virtual Coach Coach
        {
            get;
            set;
        }

        public virtual List<Match> HomeMatches
        {
            get;
            set;
        } = new List<Match>();

        public virtual List<Match> AwayMatches
        {
            get;
            set;
        } = new List<Match>();
    }
}
