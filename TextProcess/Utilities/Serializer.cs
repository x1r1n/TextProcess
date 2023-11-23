using System.Runtime.Serialization;
using System.Xml;

namespace TextProcess.Utilities
{
	public class Serializer
	{
		public string SerializeDictionaryToXml(Dictionary<string, string> keyValuePairs)
		{
			var serializer = new DataContractSerializer(typeof(Dictionary<string, string>));

			using (var stringWriter = new StringWriter())
			{
				using (XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter))
				{
					serializer.WriteObject(xmlWriter, keyValuePairs);

					return stringWriter.ToString();
				}
			}
		}

		public Dictionary<string, string> DeserializeXmlToDictionary(string xmlString)
		{
			var serializer = new DataContractSerializer(typeof(Dictionary<string, string>));

			using (var stringReader = new StringReader(xmlString))
			{
				using (var xmlReader = XmlReader.Create(stringReader))
				{
					return (Dictionary<string, string>)serializer.ReadObject(xmlReader)!;
				}
			}
		}

	}
}