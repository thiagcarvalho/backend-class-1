
using DesignPatterns.Observer.Observers;
using DesignPatterns.Subjects;

namespace DesignPatterns.Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a soccer team
            SoccerTeam soccerTeam = new SoccerTeam("Atletico Mineiro");

            SoccerFan fan1 = new SoccerFan("Thiago");
            SoccerFan fan2 = new SoccerFan("Luis");

            soccerTeam.Attach(fan1);
            soccerTeam.Attach(fan2);

            soccerTeam.SetGoal();

            soccerTeam.Detach(fan2);

            soccerTeam.SetGoal();
        }
    }
}