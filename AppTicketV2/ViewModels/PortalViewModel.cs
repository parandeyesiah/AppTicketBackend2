using DataAccess.EF.Models;

namespace AppTicketV2.ViewModels
{
    public class PortalViewModel
    {
        public int PortalID { get; set; }
        public string PortalName { get; set; }
        public string PortalUrl { get; set; }
        public int ParentPortalID { get; set; }
        public int OrgID { get; set; }
        public int WidgetID { get; set; }
        public int WidgetPropertyID { get; set; }
    }
}
