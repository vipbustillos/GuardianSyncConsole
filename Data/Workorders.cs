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
    
    public partial class Workorders : IEntityId
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public Nullable<int> RequestTypeId { get; set; }
        public Nullable<int> RequestPriorityId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string StatementOfWork { get; set; }
        public Nullable<System.DateTime> AssignedDate { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public Nullable<int> ClosedById { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Name { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> ActualCompletionDate { get; set; }
        public Nullable<System.DateTime> SlaActualResponseDate { get; set; }
        public Nullable<System.DateTime> SlaActualCompletionDate { get; set; }
        public Nullable<int> PropertyHoursInDay { get; set; }
        public Nullable<int> ActualCompletionTime { get; set; }
        public Nullable<int> ActualResponseTime { get; set; }
        public Nullable<int> SpaceId { get; set; }
        public string EmailCC { get; set; }
        public Nullable<int> AssignedToId { get; set; }
        public string RequestorLastName { get; set; }
        public string RequestorFirstName { get; set; }
        public string RequestorName { get; set; }
        public string RequestorPhone { get; set; }
        public string RequestorEmail { get; set; }
        public string RequestorFax { get; set; }
        public string RequestorCompanyName { get; set; }
        public Nullable<int> RequestorId { get; set; }
        public string CreatedByFirstName { get; set; }
        public string CreatedByLastName { get; set; }
        public string CreatedByPhone { get; set; }
        public string CreatedByEmail { get; set; }
        public Nullable<bool> BillableFlag { get; set; }
        public Nullable<bool> BillingStatusFlag { get; set; }
        public Nullable<int> TotalLaborCost { get; set; }
        public Nullable<int> TotalMaterialCost { get; set; }
        public Nullable<int> TotalMarkupint { get; set; }
        public Nullable<int> BillCodeId { get; set; }
        public Nullable<int> EstimatedLaborHours { get; set; }
        public Nullable<int> EstimatedTotalAmount { get; set; }
        public Nullable<int> TotalLaborHours { get; set; }
        public string AttachedFileName { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<System.DateTime> CreateByDatePropertyTime { get; set; }
        public string GeneralComments { get; set; }
        public Nullable<bool> NotifyRequestorFlag { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> RequestSubTypeId { get; set; }
        public Nullable<bool> AuthentryFlag { get; set; }
        public string AuthentryRemarks { get; set; }
        public string CustomerPONumber { get; set; }
        public string ExternalPOLineNumber { get; set; }
        public Nullable<int> CostCodeId { get; set; }
        public Nullable<int> EscalateToId { get; set; }
        public Nullable<int> NotToExceedAmount { get; set; }
        public Nullable<int> TotalOtherCost { get; set; }
        public Nullable<int> AssetId { get; set; }
        public Nullable<int> FailureCodeId { get; set; }
        public string PropertyExternalId { get; set; }
        public Nullable<int> TotalTax { get; set; }
        public Nullable<int> BudgetYear { get; set; }
        public Nullable<int> WorkTypeId { get; set; }
        public Nullable<int> PropertyId { get; set; }
    }
}
