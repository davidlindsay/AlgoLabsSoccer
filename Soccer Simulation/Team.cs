using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_Simulation
{
    public class Team
    {
        public List<Agent> Agents { get; set; } = new List<Agent>();
        public string Name { get; set; }

        public Team(string name)
        {
            Name = name;
        }
    }
}
