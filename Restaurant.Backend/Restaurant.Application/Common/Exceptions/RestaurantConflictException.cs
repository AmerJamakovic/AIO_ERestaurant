namespace Restaurant.Application.Common.Exceptions;

public sealed class RestaurantConflictException : Exception
{
    public RestaurantConflictException(string message)
        : base(message) { }
}
