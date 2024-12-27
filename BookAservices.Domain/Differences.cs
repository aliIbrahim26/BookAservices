namespace BookAservices.Domain
{
    public class Differences
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string? Address { get; set; }
        public string? TypeData { get; set; }
        public  ICollection<DifferenceData>? DifferenceDatas { get; set; }
    }
}
