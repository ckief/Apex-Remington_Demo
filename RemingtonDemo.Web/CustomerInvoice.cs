using System.ComponentModel.DataAnnotations;

namespace RemingtonDemo.Web
{
    public class CustomerInvoice
    {
        [Display(Name ="Sold At")]
        public string SoldAt { get; set; }

        [Display(Name ="Sold To")]
        public string SoldTo { get; set; }

        [Display(Name ="Account#")]
        public string AccountNumber { get; set; }

        [Display(Name ="Invoice#")]
        public string InvoiceNumber { get; set; }

        [Display(Name ="Customer PO#")]
        public string CustomerPONumber { get; set; }

        [Display(Name ="Order Date")]
        public string OrderDate { get; set; }

       
    }
}