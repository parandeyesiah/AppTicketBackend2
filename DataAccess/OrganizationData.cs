using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OrganizationData
    {
        public static IEnumerable<Organization> GetAllOrganizations(AppTicketDBContext context)
        {
            return context.Organizations;
        }

        public static async Task<Organization> GetOrganizationById(AppTicketDBContext context , int id)
        {
            var orgs = context.Organizations;
            return await context.Organizations.Where(o=>o.OrganizationID == id).FirstOrDefaultAsync();
        }

        public static void CreateOrganization(AppTicketDBContext context , Organization org)
        {
            context.Organizations.Add(org);
        }

        public static void DeleteOrganization(AppTicketDBContext context, int id)
        {
            var orgs = context.Organizations.ToList();
            Organization org = context.Organizations.Where(o => o.OrganizationID == id).FirstOrDefault();
            context.Organizations.Remove(org);

        }
    }
}
