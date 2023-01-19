using LoansAnalyzerAPI.DTOs;

namespace LoansAnalyzerAPI.Controllers.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        Task<IEnumerable<OfferDto>?> GetAllOffersAsync();
        Task<OfferDto> GetOfferAsync(int id);
        Task<string> GetDocumentAsync(int id);
        Task<bool> ChangeOfferState(ChangeOfferStateDTO changeOfferStateDTO);
        Task SaveDocument(int offerId, DocumentDto document);

    }
}
