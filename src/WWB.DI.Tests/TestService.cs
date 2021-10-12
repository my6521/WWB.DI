using System;

namespace WWB.DI.Tests.Service
{
    public interface IServiceAA
    {
        void Say();
    }

    public interface IServiceA
    {
        void Say();
    }

    public class ServiceA : IServiceAA, IServiceA, IScopedDependency
    {
        public void Say()
        {
            Console.WriteLine("Hello");
        }
    }
}
