using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WWB.DI.Dependencies;

namespace WWB.DI
{
    public static class Extensions
    {
        public static IServiceCollection AddServicesFromAllAssembly(this IServiceCollection services)
        {
            string[] filters =
            {
                "mscorlib",
                "netstandard",
                "dotnet",
                "api-ms-win-core",
                "runtime.",
                "System",
                "Microsoft",
                "Window",
            };

            return services.Scan(scan =>
            {
                scan
                .FromApplicationDependencies(assembly => !filters.Any(x => assembly.FullName.StartsWith(x)))
                .AddClasses(classes => classes.AssignableTo<IScopedWithInterfaces>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientWithInterfaces>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonWithInterfaces>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<IScopedOnlySelf>())
                    .AsSelf()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientOnlySelf>())
                    .AsSelf()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonOnlySelf>())
                    .AsSelf()
                    .WithSingletonLifetime();
            });
        }

    }
}
