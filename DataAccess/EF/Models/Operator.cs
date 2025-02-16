using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
    public class Operator
    {
        public int OperatorID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ParentID { get; set; }
        public ICollection<OperatorRole> OperatorRoles { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
