using System;
using System.Xml.Serialization;

namespace Utils
{
	public class Utilities
	{

		public static string ToXML(object prams)
		{
			var stringwriter = new System.IO.StringWriter();
			var serializer = new XmlSerializer(prams.GetType());
			serializer.Serialize(stringwriter, prams);
			return stringwriter.ToString();
		}

		public static object LoadFromXMLString(string xmlText)
		{
			var stringReader = new System.IO.StringReader(xmlText);
			var serializer = new XmlSerializer(typeof(object));
			return serializer.Deserialize(stringReader);
		}
	}
}
