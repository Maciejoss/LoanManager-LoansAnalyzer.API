using LoansAnalyzerAPI.Controllers.Repositories.Interfaces;
using LoansAnalyzerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LoansAnalyzerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryRepository _inquiryRepository;

        public InquiryController(IInquiryRepository inquiryRepository)
        {
            _inquiryRepository = inquiryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<InquiryDto>>> GetInquiries()
        {
            try
            {
                var inquiries = await _inquiryRepository.GetAllInquiriesAsync();
                if (inquiries == null) throw new NullReferenceException();
                return inquiries.Count() > 0 ? Ok(inquiries) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Inquiries: {ex.Message}");
            }
        }


    }
}
