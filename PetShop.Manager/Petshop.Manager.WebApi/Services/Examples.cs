namespace PetShop.Manager.WebApi.Services
{
    public interface IMySingletonService { }

    public interface IMyScopedService { }

    public interface IMyTransientService { }

    public class MySingletonService : IMySingletonService
    {
        public MySingletonService()
        {
            // Built one single time at first time it is requested by application
            // Lives throughout the application lifecycle
        }
    }

    public class MyScopedService : IMyScopedService
    {
        public MyScopedService()
        {
            // Build once at every HTTP Request
            // Lives during the HTTP Request lifecycle
        }
    }

    public class MyTransientService : IMyTransientService
    {
        public MyTransientService()
        {
            // Built every time it is requested by application
            // Lives during the scope of the consumer
        }
    }
}
