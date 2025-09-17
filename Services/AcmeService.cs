using ManagerOrder.Commons;
using ManagerOrder.Features.Orders.Views;
using ManagerOrder.Interfaces;
using System.Text;

namespace ManagerOrder.Services
{
    public class AcmeService : IAcmeService
    {
        private readonly HttpClient _httpClient;
        public AcmeService(
            IHttpClientFactory httpClientFactory
            ) {
            _httpClient = httpClientFactory.CreateClient("Acme");
        }

        public async Task<OrderStatusDto> VerifyOrder(OrderDto order)
        {
            try
            {
                var path = "EnvioPedidos/EnvioPedidosAcme/EnvioPedidoAcme";

                var request = new HttpRequestMessage(HttpMethod.Post, "")
                {
                    Content = new StringContent(XMLHelper.GenerateXML(path, XMLHelper.Serialize(path, order)), Encoding.UTF8, "text/xml")
                };

                request.Headers.Add("SOAPAction", $"http://WSDLs/{path}");

                var response = await _httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();


                var responseString = await response.Content.ReadAsStringAsync();

                var orderStatusDto = XMLHelper.Deserialize<OrderStatusDto>(responseString);


                return new OrderStatusDto() { Code = orderStatusDto.Code, Message = orderStatusDto .Message};


            }
            catch (HttpRequestException ex)
            {
                throw new BadHttpRequestException($"Se presento un error al intentar consumir el servicio {nameof(AcmeService)}: {ex.Message}");
            }
        }
    }
}
