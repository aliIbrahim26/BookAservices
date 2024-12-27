namespace BookAservices.Domain
{
    public class DifferenceData
    {
        public Guid Id { get; set; }
        public  Differences? Differences { get; set; }
        public Guid DifferencesId { get; set; }
        public  ServiceRequest? ServiceRequest { get; set; }
        public Guid ServiceRequestId { get; set; }
        public string? Reply {  get; set; } 
    }
}
