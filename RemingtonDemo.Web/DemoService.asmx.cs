using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Services;
using RemingtonDemo.Web.Data.Repositories;
using System.Web.Script.Services;

namespace RemingtonDemo.Web
{
    /// <summary>
    /// Summary description for DemoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DemoService : System.Web.Services.WebService
    {

        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCustomerInvoices(string start, string end)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            DemoRepository dm = new DemoRepository();
            IEnumerable<CustomerInvoice> invoices = dm.GetTopN(start, end, 15);
            return js.Serialize(invoices);
        }
    }
}
