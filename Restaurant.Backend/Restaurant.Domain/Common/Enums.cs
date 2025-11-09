namespace Restaurant.Domain.Common
{
public enum RoleEnum
{
    NOT_ASSIGNED,
    ADMIN,
    EMPLOYEE,
    CUSTOMER,
}

public enum JobTitleEnum
{
    MANAGER,
    WAITER,
    BARTENDER,
    KITCHEN_STAFF,
    KITCHEN_CHEF,
    OTHER,
}

public enum ReservationStatusEnum
{
    PENDING,
    CONFIRMED,
    COMPLETED,
    CANCELED,
}

public enum OrderStatusEnum
{
    OPEN,
    PREPARING,
    READY,
    CLOSED,
    INVOICED,
}

public enum OrderTypeEnum
{
    DINE_IN, // Standard table order
    TAKEAWAY,
    DELIVERY,
}

public enum PaymentMethodEnum
{
    CARD,
    CASH,
    OTHER,
}

public enum PaymentStatusEnum
{
    PAID,
    CANCELED,
    PENDING,
    WAITING,
    REFUNDED,
}

public enum TicketDestinationEnum
{
    KITCHEN,
    BAR,
}

public enum TicketStatusEnum
{
    CREATED,
    IN_PROGRESS,
    DONE,
}

public enum AllergenTypeEnum
{
    NONE,
    MILK,
    FISH,
    SOYBEANS,
    WHEAT,
}
}
