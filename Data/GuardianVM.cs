//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuardianSyncConsole.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class GuardianVM
    {
        public long EntityID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public long InvoiceNo { get; set; }
        public decimal InvoiceBallance { get; set; }
        public string Custumer { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
        public string AECode { get; set; }
    }
}