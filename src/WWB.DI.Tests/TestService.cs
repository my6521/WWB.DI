using System;
using WWB.DI.Dependencies;

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

    public class ServiceA : IServiceA, IScopedWithInterfaces
    {
        public void Say()
        {
            Console.WriteLine("Hello");
        }
    }
}
