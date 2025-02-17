using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
    public class Portal
    {
        public int PortalID { get; set; }
        public string PortalName { get; set; }
        public string PortalUrl { get; set; }
        public int ParentPortalID { get; set; }
        public int OrgID { get; set; }
        public WidgetProperty? WidgetProperty{ get; set; }
        public Organization Organization { get; set; }
        public Widget Widget { get; set; }
        public int WidgetID { get; set; }
        public int? WidgetPropertyID { get; set; }
    }
}
