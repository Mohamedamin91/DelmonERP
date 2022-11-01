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
    
    public partial class tblBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBranch()
        {
            this.tblAccountControls = new HashSet<tblAccountControl>();
            this.tblAccountSubControls = new HashSet<tblAccountSubControl>();
            this.tblCategories = new HashSet<tblCategory>();
            this.tblCustomers = new HashSet<tblCustomer>();
            this.tblCustomerInvoices = new HashSet<tblCustomerInvoice>();
            this.tblCustomerPayments = new HashSet<tblCustomerPayment>();
            this.tblEmployees = new HashSet<tblEmployee>();
            this.tblPayrolls = new HashSet<tblPayroll>();
            this.tblStocks = new HashSet<tblStock>();
            this.tblSuppliers = new HashSet<tblSupplier>();
            this.tblSupplierInvoices = new HashSet<tblSupplierInvoice>();
        }
    
        public int BranchID { get; set; }
        public int EmployeeID { get; set; }
        public int BranchTypeID { get; set; }
        public string BranchName { get; set; }
        public int BranchContact { get; set; }
        public string BranchAddress { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> BrchID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccountControl> tblAccountControls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccountSubControl> tblAccountSubControls { get; set; }
        public virtual tblBranchType tblBranchType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCategory> tblCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomer> tblCustomers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerInvoice> tblCustomerInvoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCustomerPayment> tblCustomerPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployee> tblEmployees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPayroll> tblPayrolls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStock> tblStocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupplier> tblSuppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSupplierInvoice> tblSupplierInvoices { get; set; }
    }
}
