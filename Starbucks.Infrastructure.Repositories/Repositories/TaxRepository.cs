using Newtonsoft.Json;
using Starbucks.Domain.Entities;
using Starbucks.Domain.Repositories;

namespace Starbucks.Infrastructure.Repositories
{
    public class TaxRepository  : ITaxRepository
    {
        private readonly HttpClient _httpClient;

        public TaxRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Tax>> getTaxes()
        {
            var taxItems = new List<Tax>();
            try
            {
                var path = $"https://65c190e5dc74300bce8db2ec.mockapi.io/taxes";

                using (var client = _httpClient)
                {
                    var response = await client.GetAsync(path);

                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();

                        if (!String.IsNullOrEmpty(stringResponse))
                        {
                            var taxItemsJson = JsonConvert.DeserializeObject<List<Tax>>(stringResponse);

                            if (taxItemsJson.Count != 0)
                            {
                                taxItems.AddRange(taxItemsJson);
                            }
                        }
                    }
                }

                return taxItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
