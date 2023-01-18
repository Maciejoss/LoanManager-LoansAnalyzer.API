namespace LoansAnalyzerAPI.DTOs
{
    public class InquiryDto
    {
        public int InquiryID { get; set; }
        public ClientDto Client { get; set; }
        public double Value { get; set; }
        public int InstallmentsNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public InquiryDto() {}
    }
}
