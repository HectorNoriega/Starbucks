using System.Diagnostics;

namespace Starbucks.Domain.Enums
{
    public static class OrderStatusEnum
    {
        public static readonly string PENDING = "pending";
        public static readonly string PREPARING = "preparing";
        public static readonly string PAID = "paid";
        public static readonly string DELIVERED = "delivered";
    }
}
