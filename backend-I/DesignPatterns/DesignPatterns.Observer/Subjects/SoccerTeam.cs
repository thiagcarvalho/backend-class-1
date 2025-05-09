using DesignPatterns.Observer;

namespace DesignPatterns.Subjects
{
    internal class SoccerTeam : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _teamName;

        public SoccerTeam(string teamName)
        {
            _teamName = teamName;
        }

        public string TeamName => _teamName;

        public void SetGoal()
        {
            Console.WriteLine($"Goal scored by {_teamName}!");
            Notify();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
