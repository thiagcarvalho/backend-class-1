using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeDescription;

namespace TeamClass
{
    public class Team
    {
        [SpecialDescription("This is the team name")]
        public string Name { get; set; } = string.Empty;

        [SpecialDescription("This is the Team city")]
        public string City { get; set; } = string.Empty;

        [SpecialDescription("This is the Team players")]
        public List<string> Players { get; set; } = [];
    }
}
