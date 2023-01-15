using Bank.API.DTOs;
using LoansAnalyzerAPI.DTOs;

namespace LoansAnalyzerAPI.Controllers.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        Task<IEnumerable<OfferDto>?> GetAllOffersAsync();
        Task<bool> ChangeOfferState(ChangeOfferStateDTO changeOfferStateDTO);

    }
}
