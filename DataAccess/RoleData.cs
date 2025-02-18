using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleData
    {
        public static IEnumerable<Role> GetAllRoles(AppTicketDBContext context)
        {
            return context.Role;
        }

        public static async Task<Role> GetRoleById(AppTicketDBContext context, int id)
        {

            return await context.Role.Where(o => o.RoleID == id).FirstOrDefaultAsync();
        }

        public static void CreateRole(AppTicketDBContext context, Role Role)
        {
            context.Role.Add(Role);
        }

        public static void DeleteRole(AppTicketDBContext context, int id)
        {
            //var orgs = context.Organizations.ToList();
            Role Role = context.Role.Where(o => o.RoleID == id).FirstOrDefault();
            context.Role.Remove(Role);

        }
    }
}
