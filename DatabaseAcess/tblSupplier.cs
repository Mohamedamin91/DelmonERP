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
    using System.ComponentModel.DataAnnotations;

    public partial class tblSupplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSupplier()
        {
            this.tblSupplierInvoices = new HashSet<tblSupplierInvoice>();
            this.tblSupplierPayments = new HashSet<tblSupplierPayment>();
        }
    
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "*Required!")]
        [Display(Name = "Supplier Title")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "*Required!")]
        [Display(Name = "Contact No")]
        public int SupplierConatctNo { get; set; }

        [Required(ErrorMessage = "*Required!")]
        [Display(Name = "Address")]
        public string SupplierAddress { get; set; }

        [Required(ErrorMessage = "*Required!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string SupplierEmail { get; set; }
        public string Discription { get; set; }
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
    
        public virtual tblBranch tblBranch { get; set; }
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblUser tblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupplierInvoice> tblSupplierInvoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupplierPayment> tblSupplierPayments { get; set; }
    }
}