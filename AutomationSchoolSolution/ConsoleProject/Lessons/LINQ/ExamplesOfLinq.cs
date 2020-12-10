using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Lessons.LINQ
{
    public class Order
    {
        public int Id;
        public int EvalRenewalId;
        public string PoDate;
        public string InvoiceNumber;
    }

    public class InvoiceType
    {
        public int Id;
        public string Name;
    }

    public class ExamplesOfLinq
    {
        private static List<Order> orders = new List<Order>
        {
            new Order
            {
                Id = 86482,
                EvalRenewalId = 5,
                PoDate = $"{DateTime.Now.Date : MM/dd/yyyy}",
                InvoiceNumber = "7122020104731DRAFT"
            },
            new Order
            {
                Id = 86483,
                EvalRenewalId = 6,
                PoDate = $"{DateTime.Now.Date : MM/dd/yyyy}",
                InvoiceNumber = "5262012104731DRAFT"
            },
            new Order
            {
                Id = 86484,
                EvalRenewalId = 5,
                PoDate = $"{DateTime.Now.AddDays(-56):MM/dd/yyyy}",
                InvoiceNumber = "32165"
            }
        };

        public static List<InvoiceType> types = new List<InvoiceType>
        {
            new InvoiceType
            {
                Id = 5,
                Name = "Ops"
            },
            new InvoiceType
            {
                Id = 6,
                Name = "Ops Renewal"
            }
        };

        public static void GetExamples()
        {
            var result = from order in orders
                         join type in types
                             on order.EvalRenewalId equals type.Id
                         select new { order.Id, type.Name };


            var result1 = orders.Join(types, 
                                      order => order.EvalRenewalId,
                                      type => type.Id,
                                      (order, type) => new { order.Id, type.Name});

            var t = orders.First(_ => _.InvoiceNumber.Contains("DRAFT"));
            var t1 = orders.All(_ => DateTime.Parse(_.PoDate) > DateTime.Parse("01/01/2020"));
            var t2 = orders.Count(_ => !_.InvoiceNumber.Contains("DRAFT"));

        }
    }
}
