using System.Xml.Serialization;

namespace LucidX.RequestModels
{
    [XmlRoot("ElucidateAPIParams")]
    public class EntityCodeAPIParams
    {
      
        public string connectionName { get; set; }
    }
}
