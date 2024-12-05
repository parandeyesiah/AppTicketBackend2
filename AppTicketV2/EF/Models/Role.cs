using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTicketV2.EF.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<OperatorRole> OperatorRoles { get; set; }
        public ICollection<Operator> Operators { get; set; }
    }
}
