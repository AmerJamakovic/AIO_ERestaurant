public enum RoleEnum
{
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

public enum OrderTypeEnum
{
    DINE_IN,
    TAKEAWAY,
    DELIVERY,
}

public enum OrderStatusEnum
{
    OPEN,
    PREPARING,
    READY,
    CLOSED,
    INVOICED,
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
    PENDING,
    REFUNDED,
}

public enum TicketDestinationEnum
{
    KITCHEN,
    BAR,
}

public enum TicketStatusEnum
{
    SENT,
    IN_PROGRESS,
    DONE,
}

public enum DiscountTypeEnum
{
    PERCENTAGE,
    FIXED_AMOUNT,
}
