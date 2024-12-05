using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTicketV2.EF.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public int PortalID { get; set; }
    }
}
