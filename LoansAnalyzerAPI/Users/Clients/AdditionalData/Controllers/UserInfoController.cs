using Microsoft.AspNetCore.Mvc;

namespace LoansAnalyzerAPI.Users.Clients.AdditionalData.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ApiHelper _apiHelper;

        public UserInfoController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet("JobTypes")]
        public async Task<ActionResult<string>> GetJobTypes()
        {

            using HttpResponseMessage response = await _apiHelper.GetJobTypes();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception(response.ReasonPhrase);
        }

        [HttpGet("GovernmentDocumentTypes")]
        public async Task<ActionResult<string>> GetGovernmentDocumentTypes()
        {
            using HttpResponseMessage response = await _apiHelper.GetGovernmentDocumentTypes();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            
            throw new Exception(response.ReasonPhrase);
        }
    }

}


