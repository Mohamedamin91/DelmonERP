//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAcess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCustomerInvoiceDetail
    {
        public int CustomerInvoiceDetailID { get; set; }
        public int CustomerInvoiceID { get; set; }
        public int ProductID { get; set; }
        public int SaleQuantity { get; set; }
        public int SaleUnitPrice { get; set; }
    
        public virtual tblCustomerInvoice tblCustomerInvoice { get; set; }
        public virtual tblStock tblStock { get; set; }
    }
}
