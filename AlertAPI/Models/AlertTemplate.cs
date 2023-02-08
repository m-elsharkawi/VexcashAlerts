namespace AlertAPI.Models
{
    public class AlertTemplate
    {
        public int AlertTemplateId { get; set; }
        public string AlertTemplateName { get; set; }
        public string AlertText { get; set; }
        public string AlertSubject { get; set; }
        public int AlertTypeId { get; set; }
    }
}
