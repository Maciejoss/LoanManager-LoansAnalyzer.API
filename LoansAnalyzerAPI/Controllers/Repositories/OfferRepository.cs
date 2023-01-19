using LoansAnalyzerAPI.Controllers.Repositories.Interfaces;
using LoansAnalyzerAPI.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace LoansAnalyzerAPI.Controllers.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ControllersSettings _settings;
        private readonly HttpClient _client;

        public OfferRepository(HttpClient client, IOptions<ControllersSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
        }

        public async Task<IEnumerable<OfferDto>?> GetAllOffersAsync()
        {
            IEnumerable<OfferDto>? offers = null;
            HttpResponseMessage response = await _client.GetAsync(_settings.OurApiUrl + "/Offer");
            if (response.IsSuccessStatusCode)
            {
                offers = await response.Content.ReadFromJsonAsync<IEnumerable<OfferDto>>();
            }
            return offers;
        }

        public async Task<OfferDto> GetOfferAsync(int id)
        {
            OfferDto? offer = null;
            HttpResponseMessage response = await _client.GetAsync(_settings.OurApiUrl + $"/Offer{id}");
            if (response.IsSuccessStatusCode)
            {
                offer = await response.Content.ReadFromJsonAsync<OfferDto>();
            }
            return offer;
        }

        public async Task<string> GetDocumentAsync(int id)
        {
            string documentUrl = string.Empty;
            HttpResponseMessage response = await _client.GetAsync(_settings.OurApiUrl + $"/Offer/{id}/document");
            if (response.IsSuccessStatusCode)
            {
                documentUrl = await response.Content.ReadAsStringAsync();
            }
            return documentUrl;
        }

        public async Task<bool> ChangeOfferState(ChangeOfferStateDTO changeOfferStateDTO)
        {
            string json = JsonConvert.SerializeObject(changeOfferStateDTO);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_settings.OurApiUrl + "/Offer/Change/State", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task SaveDocument(int offerId, DocumentDto document)
        {
            var streamContent = new StreamContent(document.Content.OpenReadStream());
            HttpResponseMessage response = await _client.PostAsync(_settings.OurApiUrl + $"/Offer/{offerId}/document", streamContent);
        }
    }
}
