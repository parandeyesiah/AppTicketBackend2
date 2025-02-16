namespace AppTicketV2.ViewModels
{
    public class OrganizationViewModel : APIOutput
    {
        public string OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string CreatedDate { get; set; }
        public string OrganizationType { get; set; }
        public string Address { get; set; }

    }
}
