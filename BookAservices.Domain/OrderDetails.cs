namespace BookAservices.Domain
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Services? Service { get; set; } 
        public Guid ServiceId { get; set; }

    }
}
