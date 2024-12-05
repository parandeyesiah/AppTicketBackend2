using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTicketV2.EF.Models
{
    public class Widget
    {
        public int WidgetID { get; set; }
        public string WidgetName { get; set; }

        public ICollection<Portal>  Portals { get; set; }
    }
}
