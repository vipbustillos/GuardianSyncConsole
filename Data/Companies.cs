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
    
    public partial class Companies : IEntityId
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Active { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
