using System;

namespace WWB.DI.Tests.Service
{
    public interface IServiceAA
    {
        void Say();
    }

    public interface IServiceA : IServiceAA
    {
        void Say();
    }

    public class ServiceA : IServiceA, IScopedDependency
    {
        public void Say()
        {
            Console.WriteLine("Hello");
        }
    }
}
