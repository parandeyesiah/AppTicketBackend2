using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PortalData
    {
        public static IEnumerable<Portal> GetAllPortals(AppTicketDBContext context)
        {
            return context.Portal;
        }

        public static async Task<Portal> GetPortalById(AppTicketDBContext context, int id)
        {

            return await context.Portal.Where(o => o.PortalID == id).FirstOrDefaultAsync();
        }

        public static void CreatePortal(AppTicketDBContext context, Portal portal)
        {
            context.Portal.Add(portal);
        }

        public static void DeletePortal(AppTicketDBContext context, int id)
        {
            //var orgs = context.Organizations.ToList();
            Portal portal = context.Portal.Where(o => o.PortalID == id).FirstOrDefault();
            context.Portal.Remove(portal);

        }
    }
}
