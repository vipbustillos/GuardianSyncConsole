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
    
    public partial class Assets : IEntityId
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string AssetNumber { get; set; }
        public string SerialNumber { get; set; }
        public string AssetClass { get; set; }
        public Nullable<long> PropertyId { get; set; }
        public Nullable<long> MakeId { get; set; }
        public Nullable<long> ModelId { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
