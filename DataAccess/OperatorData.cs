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
    public class OperatorData
    {
        public static IEnumerable<Operator> GetAllOperators(AppTicketDBContext context)
        {
            return context.Operator;
        }

        public static async Task<Operator> GetOperatorById(AppTicketDBContext context, int id)
        {

            return await context.Operator.Where(o => o.OperatorID == id).FirstOrDefaultAsync();
        }

        public static void CreateOperator(AppTicketDBContext context, Operator Operator)
        {
            context.Operator.Add(Operator);
        }

        public static void DeleteOperator(AppTicketDBContext context, int id)
        {
            //var orgs = context.Organizations.ToList();
            Operator Operator = context.Operator.Where(o => o.OperatorID == id).FirstOrDefault();
            context.Operator.Remove(Operator);

        }
    }
}
