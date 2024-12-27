namespace BookAservices.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public ServiceRequest? ServiceRequest { get; set; }
        public Guid ServiceRequestId { get; set; }
        public double TotalAmount { get; set; }
        public string? Status { get; set; }
        public ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}
