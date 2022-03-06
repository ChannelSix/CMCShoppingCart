using System.Runtime.CompilerServices;

namespace CMCShoppingCart;

public static class ServiceRegstration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        var typeInAssemblyToScan = typeof(ServiceRegstration);

        return services
            .AddAutoMapper(typeInAssemblyToScan)
            .RegisterSingleInterfaceImplementations();
    }

    /// <summary>
    /// Adds scoped registrations for any concrete class with a single interface implementation.
    /// </summary>
    /// <param name="services">Service collection to add registrations to.</param>
    /// <returns>Service collection reference passed on</returns>
    private static IServiceCollection RegisterSingleInterfaceImplementations(this IServiceCollection services)
    {
        var concreteTypesWithSingleInterfaceImplementaion =
            from t in typeof(ServiceRegstration).Assembly.GetExportedTypes()
            where t.IsClass && !t.IsAbstract
            let interfaces = t.GetInterfaces()
            where interfaces.Length == 1
            select new { InterfaceType = interfaces[0], ConcreteType = t };

        foreach (var typeInfo in concreteTypesWithSingleInterfaceImplementaion)
        {
            services.AddScoped(typeInfo.InterfaceType, typeInfo.ConcreteType);
        }

        return services;
    }
}