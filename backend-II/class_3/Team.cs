using System;
using System.Collections.Generic;
using AttributeDescription;
using class_3;


namespace TeamClass
{
    public class Team : IBusinessObject
    {
        [SpecialDescription("This is the team id")]
        public int Id { get; set; }

        [SpecialDescription("This is the team name")]
        public string Name { get; set; } = string.Empty;

        [SpecialDescription("This is the Team city")]
        public string City { get; set; } = string.Empty;

        [SpecialDescription("This is the Team players")]
        public List<string> Players { get; set; } = new List<string>();

        [SpecialDescription("This is the players numbers")]
        public Dictionary<string, int> PlayersNumbers { get; set; } = new Dictionary<string, int>();

    }
}
