using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using System.Text;
using System.Net.Mime;
using Courier.Models;
using Courier.TestHelper.Builders;

namespace Courier.AcceptanceTests.Controllers
{
    public class CourierShould
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        private CourierQuery A_COURIER_QUERY;

        public CourierShould()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Theory]
        [InlineData(5, "SM")]
        [InlineData(14, "M")]
        [InlineData(27, "L")]
        [InlineData(45, "XL")]
        [InlineData(19, "SM", "M")]
        [InlineData(32, "SM", "L")]
        [InlineData(50, "SM", "XL")]
        [InlineData(41, "M", "L")]
        [InlineData(59, "M", "XL")]
        [InlineData(72, "L", "XL")]
        [InlineData(91, "SM", "M", "L", "XL")]
        public async Task return_total_price_for_parcels(
            decimal expectedTotalPrice,
            params string[] dimensions)
        {
            A_COURIER_QUERY =
                CourierQueryBuilder.ACourierQuery()
                .WithParcelsOfDimension(dimensions)
                .Build();

            StringContent stringContent = SerializeCourierQuery();

            CourierResponse courierResponse = await DeserializeCourierResponse(stringContent);

            Assert.Equal(expectedTotalPrice, courierResponse.TotalPrice);
        }

        [Fact]
        public async Task return_collection_of_items_with_prices_for_each()
        {
            A_COURIER_QUERY =
                CourierQueryBuilder.ACourierQuery()
                .WithLParcel()
                .WithXLParcel()
                .Build();

            StringContent stringContent = SerializeCourierQuery();

            CourierResponse courierResponse = await DeserializeCourierResponse(stringContent);

            Assert.Equal(27, courierResponse.Parcels[0].Cost);
            Assert.Equal(45, courierResponse.Parcels[1].Cost);
        }

        [Fact]
        public async Task return_matching_json()
        {
            string expectedJson = "{\"totalPrice\":72.0,\"parcels\":[{\"cost\":27.0},{\"cost\":45.0}],\"speedyShipping\":{\"totalPrice\":144.0}}";
            A_COURIER_QUERY =
                CourierQueryBuilder.ACourierQuery()
                .WithLParcel()
                .WithXLParcel()
                .Build();

            StringContent stringContent = SerializeCourierQuery();

            string responseJson = await ExtractJsonResponse(stringContent);

            Assert.Equal(expectedJson, responseJson);
        }

        [Fact]
        public async Task return_speedy_delivery_option()
        {
            A_COURIER_QUERY =
                CourierQueryBuilder.ACourierQuery()
                .WithLParcel()
                .WithXLParcel()
                .Build();

            StringContent stringContent = SerializeCourierQuery();

            CourierResponse courierResponse = await DeserializeCourierResponse(stringContent);

            Assert.Equal(72, courierResponse.TotalPrice);
            Assert.Equal(144, courierResponse.SpeedyShipping.TotalPrice);
        }

        [Fact]
        public async Task add_weight_quota_to_dimension()
        {
            A_COURIER_QUERY =
                CourierQueryBuilder.ACourierQuery()
                .WithLParcel()
                .Build();

            StringContent stringContent = SerializeCourierQuery();

            CourierResponse courierResponse = await DeserializeCourierResponse(stringContent);

            Assert.Equal(27, courierResponse.TotalPrice);
            Assert.Equal(27, courierResponse.Parcels[0].Cost);
        }

        private StringContent SerializeCourierQuery()
        {
            var json = JsonConvert.SerializeObject(A_COURIER_QUERY);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            return stringContent;
        }

        private async Task<CourierResponse> DeserializeCourierResponse(StringContent stringContent)
        {
            var response = await client.PostAsync("/api/Courier", stringContent);

            response.EnsureSuccessStatusCode();
            string stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<CourierResponse>(stringData);
            return data;
        }

        private async Task<string> ExtractJsonResponse(StringContent stringContent)
        {
            var response = await client.PostAsync("/api/Courier", stringContent);

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
