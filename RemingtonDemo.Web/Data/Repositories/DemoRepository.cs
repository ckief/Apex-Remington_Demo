using System;
using System.Collections.Generic;
using System.Linq;
using RemingtonDemo.Web.Data.Persistence;

namespace RemingtonDemo.Web.Data.Repositories
{
    public class DemoRepository
    {
        private DemoDataDataContext dbContext = new DemoDataDataContext();
        
        public IEnumerable<CustomerInvoice> GetTopN(string start, string end, int records)
        {
            DateTime dtStart = Convert.ToDateTime(start);
            DateTime dtEnd = Convert.ToDateTime(end);
            IEnumerable<CustomerInvoice> result = (from o in dbContext.SalesOrderHeaders
                                                   join c in dbContext.Customers on o.CustomerID equals c.CustomerID
                                                   join p in dbContext.Persons on c.PersonID equals p.BusinessEntityID
                                                   join s in dbContext.Stores on c.StoreID equals s.BusinessEntityID
                                                   where (o.DueDate.Date > dtStart.Date && o.DueDate.Date <= dtEnd.Date)
                                                   orderby o.OrderDate ascending
                                                   select new CustomerInvoice
                                                   {
                                                       SoldAt = s.Name,
                                                       SoldTo = p.FirstName + " " + p.LastName,
                                                       AccountNumber = c.AccountNumber,
                                                       InvoiceNumber = o.SalesOrderNumber,
                                                       CustomerPONumber = o.PurchaseOrderNumber,
                                                       OrderDate = string.Format("{0:yyyy-MM-dd}", o.OrderDate)


                                                   }).Take(records);

            return result;
        }

        public IEnumerable<CustomerInvoice> GetAll(DateTime start, DateTime end)
        {
            IEnumerable<CustomerInvoice> result = (from o in dbContext.SalesOrderHeaders
                                                   join c in dbContext.Customers on o.CustomerID equals c.CustomerID
                                                   join p in dbContext.Persons on c.PersonID equals p.BusinessEntityID
                                                   join s in dbContext.Stores on c.StoreID equals s.BusinessEntityID
                                                   where (o.DueDate.Date > start.Date && o.DueDate.Date <= end.Date)
                                                   orderby o.OrderDate ascending
                                                   select new CustomerInvoice
                                                   {
                                                       SoldAt = s.Name,
                                                       SoldTo = p.FirstName + " " + p.LastName,
                                                       AccountNumber = c.AccountNumber,
                                                       InvoiceNumber = o.SalesOrderNumber,
                                                       CustomerPONumber = o.PurchaseOrderNumber,
                                                       OrderDate = string.Format("{0:yyyy-MM-dd}", o.OrderDate)


                                                   });

            return result;
        }

    }
}