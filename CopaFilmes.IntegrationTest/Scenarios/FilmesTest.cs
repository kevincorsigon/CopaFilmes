using CopaFilmes.Api;
using CopaFilmes.IntegrationTest.Fixtures;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilmes.IntegrationTest.Scenarios
{
    public class FilmesTest
    {
        public TestFixture<Startup> Fixture { get; private set; }

        public FilmesTest()
        {
            Fixture = new TestFixture<Startup>();
        }

        [Fact]
        public async Task Filme_Get_ReturnsOkResponse()
        {
            var response = await Fixture.Client.GetAsync("/api/filme");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Filme_Get_ReturnsNotFoundResponse()
        {
            var response = await Fixture.Client.GetAsync("/api/filme/23135");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }       
    }
}
