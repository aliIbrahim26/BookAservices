namespace BookAservices.Domain
{
    public class OptionsDifference
    {
        public Guid Id { get; set; }
        public Guid DifferencesId { get; set; }
        public string? Address { get; set; }
        public ICollection<OptionsDifferenceData>? optionsDifferenceDatas { get; set; }
    }
}
