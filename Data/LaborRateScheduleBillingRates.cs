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
    
    public partial class LaborRateScheduleBillingRates : IEntityId
    {
        public long Id { get; set; }
        public Nullable<long> RateScheduleId { get; set; }
        public Nullable<long> RequestTypeActivityId { get; set; }
        public Nullable<long> EmployeeId { get; set; }
        public Nullable<int> HourlyRate { get; set; }
        public Nullable<int> OtHourlyRate { get; set; }
        public Nullable<int> TwoOtHourlyRate { get; set; }
        public Nullable<long> PositionId { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
