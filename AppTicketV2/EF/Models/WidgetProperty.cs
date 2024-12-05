using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTicketV2.EF.Models
{
    public class WidgetProperty
    {
        public int WidgetPropertyID { get; set; }
        public int WidgetID { get; set; }
        public string WidgetColor { get; set; }
        public string WidgetIcon { get; set; }
        public string WidgetPosition { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedDateFa { get; set; }
    }
}
