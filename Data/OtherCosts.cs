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
    
    public partial class OtherCosts : IEntityId
    {
        public long Id { get; set; }
        public Nullable<long> OtherCostTypeId { get; set; }
        public string OtherCostType { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}