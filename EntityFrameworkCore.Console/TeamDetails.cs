using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Console
{
    internal class TeamDetails
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string CoachName { get; set; }

        public int TotalHomeGoals { get; set; }

        public int TotalAwayGoals { get; set; }
    }
}
