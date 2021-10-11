using Microsoft.Extensions.DependencyInjection;
using WWB.DI.Tests.Service;
using Xunit;

namespace WWB.DI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var collection = new ServiceCollection();
            collection.AddServicesFromAllAssembly();

            var serviceProvider = collection.BuildServiceProvider();
            var serviceA = serviceProvider.GetService<IServiceA>();
            var serviceAA = serviceProvider.GetService<IServiceAA>();
            serviceA.Say();
            serviceAA.Say();
        }
    }
}
