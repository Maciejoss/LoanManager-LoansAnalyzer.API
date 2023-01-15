using LoansAnalyzerAPI.Users.Employees;

namespace LoansAnalyzerAPI.DTOs
{
    public enum OfferStatus : byte
    {
        Created,
        Approved,
        Declined,
    }
    public class OfferDto
    {
        public int OfferID { get; set; }
        public double Percentage { get; set; }
        public double MonthlyInstallment { get; set; }
        public double RequestedValue { get; set; }
        public int RequestedPeriodInMonth { get; set; }
        public int StatusID { get; set; }
        public string StatusDescription { get => ((OfferStatus)StatusID).ToString(); }
        public int InquiryID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Employee? Reviewer { get; set; }
        public Uri? DocumentLink { get; set; }
        public DateTime DocumentLinkValidDate { get; set; }

        public OfferDto() { }
    }
}
