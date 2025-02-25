using DataAccess.EF.Models;

namespace AppTicketV2.DTOs
{
    public class OrganizationDTO
    {
        public string OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public short OrganizationType { get; set; }
        public string Address { get; set; }
        public string? Tel { get; set; }
    }
}
