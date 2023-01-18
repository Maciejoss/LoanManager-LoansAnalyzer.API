using LoansAnalyzerAPI.DTOs;

namespace LoansAnalyzerAPI.Controllers.Repositories.Interfaces
{
    public interface IInquiryRepository
    {
        Task<IEnumerable<InquiryDto>?> GetAllInquiriesAsync();
    }
}
