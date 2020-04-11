using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CopaFilmes.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CopaFilmes.Infra.Services
{
    public class FilmeService : IFilmeService
    {
        #region Construtor
        public FilmeService(IConfiguration config)
        {
            configuration = config;
        }
        #endregion

        #region Atributos
        private static HttpClient _httpClient;

        private static IConfiguration configuration;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());

        #endregion

        #region Métodos
        public async Task<IEnumerable<Filme>> GetFilmesAsync()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(configuration.GetSection("Urls")["apiFilmes"]);
            if (response.IsSuccessStatusCode)
            {              
                string responseBodyAsText = await response.Content.ReadAsStringAsync();               
                return JsonSerializer.Deserialize<List<Filme>>(responseBodyAsText, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true } );
            }
            return default(IEnumerable<Filme>);
        }
        #endregion
    }
}
