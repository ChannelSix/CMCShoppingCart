namespace CMCShoppingCart.Common;
public static class ObjectExtensions
{
    public static Task<T> AsTask<T>(this T value)
        => Task.FromResult(value);
}

