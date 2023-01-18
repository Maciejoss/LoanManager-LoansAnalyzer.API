namespace LoansAnalyzerAPI.DTOs
{
    public class ChangeOfferStateDTO
    {
        public int id { get; set; }
        public Guid employeeId { get; set; }
        public OfferStatus status { get; set; }

        public ChangeOfferStateDTO() { }
    }
}
