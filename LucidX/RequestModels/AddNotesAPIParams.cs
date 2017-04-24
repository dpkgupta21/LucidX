using System.Xml.Serialization;

namespace LucidX.RequestModels
{
    [XmlRoot("ElucidateAPIParams")]
    public class AddNotesAPIParams
    {
        public string entityCode { get; set; }
        public string accountCode { get; set; }
        public string notesHeader { get; set; }
        public string notesDetail { get; set; }
        public string notesDetail_Add { get; set; }
        public string userId { get; set; }
        public string actionTypeId { get; set; }
        public string sendTo { get; set; }
        public string privacyId { get; set; }
        public string accountId { get; set; }
        public string notesId { get; set; }
        public string connectionName { get; set; }
       

    }
}
