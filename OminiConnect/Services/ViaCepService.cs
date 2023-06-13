
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ViaCEPService
    {
        private readonly HttpClient _httpClient;

        public ViaCEPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddressDTO> GetAddressByPostalCode(string postalCode)
        {
            string url = $"https://viacep.com.br/ws/{postalCode}/json/";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                // Deserializar o conteúdo JSON em um objeto AddressDTO
                AddressDTO addressDTO = JsonSerializer.Deserialize<AddressDTO>(content);

                return addressDTO;
            }

            return null;
        }
    }

