namespace Restaurant.Application.Common.Exceptions;

public sealed class RestaurantNotFoundException : Exception
{
    public RestaurantNotFoundException(string message)
        : base(message) { }
}
