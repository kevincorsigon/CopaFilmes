using CopaFilmes.Api;
using CopaFilmes.Api.Models;
using CopaFilmes.IntegrationTest.Fixtures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilmes.IntegrationTest.Scenarios
{
    public class CampeonatosTest
    {
        public TestFixture<Startup> Fixture { get; private set; }

        public CampeonatosTest()
        {
            Fixture = new TestFixture<Startup>();
        }

        [Fact]
        public async Task Campeonato_Post_ReturnsOkResponse()
        {
            var response = await Fixture.Client.GetAsync("/api/filme");
            response.EnsureSuccessStatusCode();
            string responseBodyAsText = await response.Content.ReadAsStringAsync();

            var filmesPack = JsonSerializer.Deserialize<ResponseWrapper<List<FilmeDto>>>(responseBodyAsText, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var campeonato = new CopaFilmes.Api.Models.CampeonatoDto()
            {
                Filmes = filmesPack.Result.Take(8).ToList()
            };

            var contentString = new StringContent(JsonSerializer.Serialize(campeonato), Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");      

            var responsePost = await Fixture.Client.PostAsync("/api/campeonato", contentString);
            responsePost.EnsureSuccessStatusCode();
            responsePost.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Campeonato_Post_ReturnsBadRequestResponse()
        {
            var response = await Fixture.Client.GetAsync("/api/filme");
            response.EnsureSuccessStatusCode();
            string responseBodyAsText = await response.Content.ReadAsStringAsync();

            var filmesPack = JsonSerializer.Deserialize<ResponseWrapper<List<FilmeDto>>>(responseBodyAsText, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var campeonato = new CopaFilmes.Api.Models.CampeonatoDto()
            {
                Filmes = filmesPack.Result.Take(2).ToList()
            };

            var contentString = new StringContent(JsonSerializer.Serialize(campeonato), Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");

            var responsePost = await Fixture.Client.PostAsync("/api/campeonato", contentString);
            responsePost.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

    }
}
