using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CMCShoppingCart.Tests.Integration;

internal static class IntegrationTestHelper
{
    private readonly static Lazy<IServiceProvider> _serviceProvider = new(CreateServiceProvider);

    /// <summary>
    /// Creates a scoped service provider so we can get services registered as scope in a non-scoped context (i.e. testing environment). 
    /// </summary>
    /// <returns></returns>
    public static ScopedServiceProvider CreateScopedServiceProvider()
        => new(_serviceProvider.Value);

    private static IServiceProvider CreateServiceProvider()
    {
        var result = new ServiceCollection()
            .RegisterServices()
            .RegisterControllers()
            .BuildServiceProvider();

        return result;
    }

    /// <summary>
    /// Registers controller so we can get them for integration tests.
    /// </summary>
    private static IServiceCollection RegisterControllers(this IServiceCollection services)
    {
        var controllerTypes = typeof(ServiceRegstration).Assembly.ExportedTypes
            .Where(t => !t.IsAbstract && t.BaseType == typeof(ControllerBase));

        foreach (var controllerType in controllerTypes)
            services.AddScoped(controllerType);

        return services;
    }
}

/// <summary>
/// Wrapper class for providing scoped services in a non-scoped environment (i.e. integration tests).
/// </summary>
internal class ScopedServiceProvider : IServiceProvider, IDisposable
{
    private readonly IServiceScope _scope;

    public ScopedServiceProvider(IServiceProvider serviceProvider)
    {
        _scope = serviceProvider.CreateScope();        
    }

    public void Dispose()
        => _scope.Dispose();

    public object? GetService(Type serviceType)
        => _scope.ServiceProvider.GetService(serviceType);
}