using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ANZ.GoodReadBook.DBModel.Model;
using Newtonsoft.Json;
using Xunit;

namespace ANZ.GoodReadsBook.IntegrationTest
{
    public class BooksControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public BooksControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetPlayers()
        {
            //api/Book

            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/Book");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<IEnumerable<Books>>(stringResponse);
            Assert.Equal(2, players.Count());
            Assert.Contains(players, p => p.AverageRating == "4.5");
            Assert.Contains(players, p => p.AverageRating == "3.5");
        }
    }
}
