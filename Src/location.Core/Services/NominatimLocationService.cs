using location.Core.Entities;
using location.Core.Entities.Generated;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace location.Core.Services
{
    public class NominatimLocationService : ILocationService
    {
        private const string URL = "http://nominatim.openstreetmap.org/reverse";
        private const string URL_PARAMS = "?format=json&lat={0}&lon={1}";
        
        private readonly ILogger<NominatimLocationService> _logger;
        private readonly HttpClient _httpClient;

        public NominatimLocationService(ILogger<NominatimLocationService> logger,
            IHttpClientProvider httpClientProvider)
        {
            _logger = logger;
            _httpClient = httpClientProvider.Get();
            _httpClient.DefaultRequestHeaders.Add("user-agent", "custom location app");
        }

        public async Task<Entities.Address> Get(double latitude, double longitude, string locale)
        {
            _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
            _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(locale));

            var url = string.Format(CultureInfo.InvariantCulture, URL + URL_PARAMS, latitude, longitude);
            var result = await _httpClient.GetStringAsync(url);

            _logger.LogInformation($"Data from {url} downloaded...");

            var o = (NominatimAddr)JsonSerializer.Deserialize(result, typeof(NominatimAddr));

            return CreateAddress(o.address);
        }

        private Entities.Address CreateAddress(Entities.Generated.Address address)
        {
            return new Entities.Address(
                address.house_number,
                address.road,
                address.suburb,
                address.city,
                address.postcode,
                address.country,
                address.country_code);
        }
    }
}
