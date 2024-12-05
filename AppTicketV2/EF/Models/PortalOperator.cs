using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTicketV2.EF.Models
{
    public class PortalOperator
    {
        public int PortalOperatorID { get; set; }
        public int PortalID { get; set; }
        public int OperatorID { get; set; }
    }
}
