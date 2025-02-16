using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class WidgetData
    {
        public static IEnumerable<Widget> GetAllWidgets(AppTicketDBContext context)
        {
            return context.Widget;
        }

        public static async Task<Widget> GetWidgetById(AppTicketDBContext context , int id)
        {
            
            return await context.Widget.Where(o=>o.WidgetID == id).FirstOrDefaultAsync();
        }

        public static void CreateWidget(AppTicketDBContext context , Widget widget)
        {
            context.Widget.Add(widget);
        }

        public static void DeleteWidget(AppTicketDBContext context, int id)
        {
            //var orgs = context.Organizations.ToList();
            Widget widget = context.Widget.Where(o => o.WidgetID == id).FirstOrDefault();
            context.Widget.Remove(widget);

        }
    }
}
