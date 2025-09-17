using System.Xml.Serialization;

namespace ManagerOrder.Features.Orders.Views
{
    [XmlRoot("EnvioPedidoResponse", Namespace = "http://WSDLs/EnvioPedidos/EnvioPedidosAcme")]
    public class OrderStatusDto
    {
        [XmlElement("Codigo")]
        public required string Code { get; set; }

        [XmlElement("Mensaje")]
        public required string Message { get; set; }
    }
}
