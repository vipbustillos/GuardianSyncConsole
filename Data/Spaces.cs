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
    
    public partial class Spaces : IEntityId
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<long> RateScheduleId { get; set; }
        public Nullable<long> PropertyId { get; set; }
        public Nullable<long> ExternalFloorId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string PropertyExternalId { get; set; }
    }
}