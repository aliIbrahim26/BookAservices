namespace BookAservices.Domain
{
    public class OptionsDifferenceData
    {
        public Guid Id { get; set; }
        public DifferenceData? DifferenceData { get; set; }
        public Guid DifferenceDataId { get; set; }
        public OptionsDifference OptionsDifference { get; set; }
        public Guid OptionsDifferenceId { get; set; }
    }
}
