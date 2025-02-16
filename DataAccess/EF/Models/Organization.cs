using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.EF.Models
{
    public class Organization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedDateFa { get; set; }
        public string? OrganizationType { get; set; }
        public string? Address { get; set; }
        public string? Tel { get; set; }
        public ICollection<Portal> Portals { get; set; }

    }
}
