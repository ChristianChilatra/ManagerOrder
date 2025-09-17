using ManagerOrder.Features.Orders.Views;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ManagerOrder.Commons
{
    public static class XMLHelper
    {
        public static T Deserialize<T>(string xmlString) where T : class
        {

            var type = typeof(T);
            var xmlRootName = type.GetCustomAttribute<XmlRootAttribute>().ElementName;

            var document = XDocument.Parse(xmlString);
            var element = document.Descendants().FirstOrDefault(x => x.Name.LocalName == xmlRootName);

            using var reader = new StringReader(element.ToString());

            return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
        }

        public static string Serialize<T>(string path, T element)
        {

            var type = typeof(T);
            var xmlRootName = type.GetCustomAttribute<XmlRootAttribute>().ElementName;

            var xelements = new List<XElement>();

            foreach (var prop in type.GetProperties())
            {
                var elementAttr = prop.GetCustomAttribute<XmlElementAttribute>();
                if (elementAttr != null)
                {
                    xelements.Add(new XElement(elementAttr.ElementName, prop.GetValue(element), new XAttribute(XNamespace.Xmlns + "tns", $"http://WSDLs/{path}")));
                }
            }

            return new XElement(xmlRootName,xelements, new XAttribute(XNamespace.Xmlns + "tns", $"http://WSDLs/{path}")).ToString();

        }
        public static string GenerateXML(string path, string body)
        {
            XNamespace soapEnv = "http://schemas.xmlsoap.org/soap/envelope/";

            var soapEnvelope = new XElement(soapEnv + "Envelope",
                new XAttribute(XNamespace.Xmlns + "soap", soapEnv),
                new XAttribute(XNamespace.Xmlns + "tns", $"http://WSDLs/{path}"),
                new XElement(soapEnv + "Header"),
                new XElement(soapEnv + "Body",
                    XElement.Parse(body)
                )
            );

            return new XDocument(new XDeclaration("1.0", "utf-8", "yes"), soapEnvelope).ToString();
        }
    }
}
