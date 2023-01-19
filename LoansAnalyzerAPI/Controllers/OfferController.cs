using LoansAnalyzerAPI.Controllers.Repositories.Interfaces;
using LoansAnalyzerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LoansAnalyzerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<OfferDto>>> GetOffers()
        {
            try
            {
                var offers = await _offerRepository.GetAllOffersAsync();
                if (offers == null) throw new NullReferenceException();
                return offers.Count() > 0 ? Ok(offers) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Offers: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDto>> GetOffer(int id)
        {
            try
            {
                var offer = await _offerRepository.GetOfferAsync(id);
                return offer;
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Offer: {ex.Message}");
            }
        }
        
        [HttpGet("{id}/document")]
        public async Task<ActionResult<string>> GetOfferDocument(int id)
        {
            try
            {
                var documentUrl = await _offerRepository.GetDocumentAsync(id);
                return documentUrl != string.Empty ? NoContent() : Ok(documentUrl);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get document: {ex.Message}");
            }
        }
        
        [HttpPost("{id}/document")]
        public async Task<ActionResult> SaveDocument([FromForm] DocumentDto document)
        {
            try
            {
                await _offerRepository.SaveDocument(document.OfferId, document);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save document: {ex.Message}");
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<string>> GetOfferDocument(int id)
        {
            try
            {
                var documentUrl = await _offerRepository.GetDocument(id);
                return documentUrl != string.Empty ? NoContent() : Ok(documentUrl);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Inquiries: {ex.Message}");
            }
        }

        [HttpPost("Change/State")]
        public async Task<ActionResult> ChangeOfferState([FromBody] ChangeOfferStateDTO changeOfferStateDTO)
        {
            try
            {
                var result = await _offerRepository.ChangeOfferState(changeOfferStateDTO);
                return result ? Ok(result) : NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to change state of Offer with Id {changeOfferStateDTO.id}: {ex.Message}");
            }
        }
    }
}
