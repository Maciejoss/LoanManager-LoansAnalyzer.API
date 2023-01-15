using Bank.API.DTOs;
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
