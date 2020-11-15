using AutoFixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TelecomProvider.Model;
using Xunit;
using ContractPhone = TelecomProvider.Controllers.TelecomProviderContract.DTO.Phone;

namespace TelecomProvider.AcceptanceTests
{
    public class TelecomProviderShould
    {
        private readonly Fixture fixture;
        private readonly TestServer server;
        private readonly HttpClient client;

        private readonly ContractPhone A_CONTRACT_PHONE;
        private readonly int A_CUSTOMER_ID;

        public TelecomProviderShould()
        {
            fixture = new Fixture();
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
            A_CONTRACT_PHONE = fixture.Create<ContractPhone>();
            A_CUSTOMER_ID = fixture.Create<int>();
        }

        [Fact]
        public async Task give_empty_phones_when_there_are_no_phones_registered()
        {
            var response = await client.GetAsync("/api/TelecomProvider");

            response.EnsureSuccessStatusCode();
            string stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Phone>>(stringData);

            Assert.Empty(data);
        }

        [Fact]
        public async Task give_all_phones()
        {
            var response = RegisterOneCustomer(A_CONTRACT_PHONE);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            response = await client.GetAsync("/api/TelecomProvider");
            response.EnsureSuccessStatusCode();
            string stringData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<Phone>>(stringData);

            Assert.NotEmpty(data);
            Assert.Single(data);
            Assert.Equal(data.First().Number, A_CONTRACT_PHONE.PhoneNumber);
        }

        [Fact]
        public async Task give_all_phones_from_same_customer()
        {
            int customerFirstPhone = fixture.Create<int>();
            var response = RegisterOneCustomerWithPhone(A_CUSTOMER_ID, customerFirstPhone);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            int customerSecondPhone = fixture.Create<int>();
            response = RegisterOneCustomerWithPhone(A_CUSTOMER_ID, customerSecondPhone);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            response = await client.GetAsync($"/api/TelecomProvider/{A_CUSTOMER_ID}");
            response.EnsureSuccessStatusCode();
            string stringData = response.Content.ReadAsStringAsync().Result;
            var customerPhones = JsonConvert.DeserializeObject<List<Phone>>(stringData);

            Assert.Equal(2, customerPhones.Count);
            Assert.Equal(customerFirstPhone, customerPhones.ElementAt(0).Number);
            Assert.Equal(customerSecondPhone, customerPhones.ElementAt(1).Number);
        }

        [Fact]
        public void give_an_ok_when_activating_a_newPhone()
        {
            var response = RegisterOneCustomer(A_CONTRACT_PHONE);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public void give_exception_when_adding_a_phone_which_has_already_been_registered()
        {
            var response = RegisterOneCustomer(A_CONTRACT_PHONE);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            response = RegisterOneCustomer(A_CONTRACT_PHONE);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        private HttpResponseMessage RegisterOneCustomer(ContractPhone contractPhone)
        {
            var json = JsonConvert.SerializeObject(contractPhone);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            return client.PostAsync("/api/TelecomProvider", stringContent).Result;
        }

        private HttpResponseMessage RegisterOneCustomerWithPhone(int customerId, int phoneNumber)
        {
            var contractPhone = new ContractPhone { CustomerId = customerId, PhoneNumber = phoneNumber };
            var json = JsonConvert.SerializeObject(contractPhone);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            return client.PostAsync("/api/TelecomProvider", stringContent).Result;
        }
    }
}
