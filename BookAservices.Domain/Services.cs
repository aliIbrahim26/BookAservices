namespace BookAservices.Domain
{
    public class Services
    {
        public required Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public double Price { get; set; }

    }
}
