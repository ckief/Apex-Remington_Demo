using System;
using System.Web.UI;
using RemingtonDemo.Web.Data.Repositories;
using System.IO;

namespace RemingtonDemo.Web
{
    public partial class DemoView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var today = DateTime.Today;
                var month = new DateTime(today.Year, today.Month, 1);
                var first = month.AddMonths(-1);
                var last = month.AddDays(-1);
                TxtStart.Text = first.ToString("MM/dd/yyyy");
                TxtEnd.Text = last.ToString("MM/dd/yyyy");

            }
        }

        protected void BtnRun_Click(object sender, EventArgs e)
        {
            DateTime dt1 = Convert.ToDateTime(TxtStart.Text);
            DateTime dt2 = Convert.ToDateTime(TxtEnd.Text);
            if (dt1.Year <= 2014 && dt2.Year <= 2014)
            {
                DemoRepository repo = new DemoRepository();
                GridView1.EnableDynamicData(typeof(CustomerInvoice));
                GridView1.DataSource = repo.GetTopN(TxtStart.Text, TxtEnd.Text, 15);
                GridView1.DataBind();
            }
            else
            {
                Response.Write("Order Dates do not exceed 2014");
            }
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            
            Excel ex = new Excel();
            ex.Main(Convert.ToDateTime(TxtStart.Text), Convert.ToDateTime(TxtEnd.Text));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Invoice.xlsx");
            Response.TransmitFile(Server.MapPath("~/temp/Invoice.xlsx"));
            Response.Flush();
            File.Delete(Server.MapPath("~/temp/Invoice.xlsx"));
            Response.End();
        }
    }
}