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
    SENT,
    IN_PROGRESS,
    DONE,
}

public enum DiscountTypeEnum
{
    PERCENTAGE,
    FIXED_AMOUNT,
}

public enum AllergenTypeEnum
{
    NONE,
    MILK,
    FISH,
    SOYBEANS,
    WHEAT,
}

public enum OrderSourceEnum
{
    ONLINE, // Customer only
    PHONE, // Employee & customer
    DINE_IN, // Employee & table
    TAKEAWAY, // Employee or customer
    DELIVERY, // Customer only with address
}
