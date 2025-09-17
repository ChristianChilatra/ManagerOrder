using System.Xml.Serialization;

namespace ManagerOrder.Features.Orders.Views
{
    [XmlRoot("EnvioPedidoRequest")]

    public class OrderDto
    {
        [XmlElement("pedido")]
        public required long Order { get; set; }

        [XmlElement("Cantidad")]
        public required int Quantity { get; set; }

        [XmlElement("EAN")]
        public required string EAN { get; set; }

        [XmlElement("Producto")]
        public required string Product { get; set; }

        [XmlElement("Cedula")]
        public required long Document { get; set; }

        [XmlElement("Direccion")]
        public required string Address { get; set; }
    }
}
