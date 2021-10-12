﻿using Microsoft.Extensions.DependencyInjection;
using System.Linq;

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
                .AddClasses(classes => classes.AssignableTo<IScopedDependency>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientDependency>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonDependency>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<IScopedDependencyOnlySelf>())
                    .AsSelf()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientDependencyOnlySelf>())
                    .AsSelf()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonDependencyOnlySelf>())
                    .AsSelf()
                    .WithSingletonLifetime();
            });
        }

    }
}
