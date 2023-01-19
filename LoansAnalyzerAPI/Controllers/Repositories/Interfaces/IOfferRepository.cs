using LoansAnalyzerAPI.DTOs;

namespace LoansAnalyzerAPI.Controllers.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        Task<IEnumerable<OfferDto>?> GetAllOffersAsync();
        Task<string> GetDocument(int id);
        Task<bool> ChangeOfferState(ChangeOfferStateDTO changeOfferStateDTO);

    }
}
