using DesignPatterns.Subjects;

namespace DesignPatterns.Observer.Observers
{
    internal class SoccerFan : IObserver
    {
        private string _name;

        public SoccerFan(string name)
        {
            _name = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is SoccerTeam soccerTeam)
            {
                Console.WriteLine($"SoccerFan {_name} notified. The team {soccerTeam.TeamName} scored a goal");
            }
        }
    }
}
