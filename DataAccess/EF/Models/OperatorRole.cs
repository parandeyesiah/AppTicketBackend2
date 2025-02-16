using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
    public class OperatorRole
    {
        public int OperatorRoleID { get; set; }
        public int OperatorID { get; set; }
        public int RoleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedDateFa { get; set; }
        public Operator Operator { get; set; }
        public Role Role { get; set; }
    }
}
