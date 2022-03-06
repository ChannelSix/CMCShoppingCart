namespace CMCShoppingCart.Common;
public static class ServiceProviderExtensions
{
    public static TService GetServiceOrThrow<TService>(this IServiceProvider serviceProvider)
    {
        var result = serviceProvider.GetService<TService>();
        if (result == null)
            throw new Exception($"Attempt to get service of type {typeof(TService)} returned null");
        return result;
    }
}
