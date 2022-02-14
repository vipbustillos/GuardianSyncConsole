using GuardianSyncConsole.Data;
using GuardianSyncConsole.Services;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;

namespace GuardianSyncConsole
{
    public class BackgroundService
    {
        private ILog mLogger;

        public void Star()
        {
            this.ConfigureLog4Net();
            try
            {
                this.mLogger.Info((object)"**************************** Application Started ****************************");
                this.sync();
                this.mLogger.Info((object)"**************************** Application Stoped ****************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                this.mLogger.Error((object)string.Format("Start Exeption : {0}", (object)ex));
            }
        }

        public void ConfigureLog4Net()
        {
            try
            {
                GlobalContext.Properties["LogFileName"] = (object)"GuardianServiceLog";
                XmlConfigurator.Configure();
                this.mLogger = LogManager.GetLogger("servicelog");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void sync()
        {
            Console.WriteLine("************* SYNCHRONIZE *************/n/n");
            this.mLogger.Info((object)"[sync] Synchronization Started");
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------ActivityGroups-------------------------------");
                this.mLogger.Info((object)" ActivityGroups synchronization ");
                List<ActivityGroups> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<ActivityGroups>("activitygroups", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<ActivityGroups>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Assets-------------------------------");
                this.mLogger.Info((object)" Assets synchronization ");
                List<Assets> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Assets>("assets", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Assets>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Attachments-------------------------------");
                this.mLogger.Info((object)" Attachments synchronization ");
                List<Attachments> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Attachments>("attachments", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Attachments>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------BillCodes-------------------------------");
                this.mLogger.Info((object)" BillCodes synchronization ");
                List<BillCodes> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<BillCodes>("billcodes", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<BillCodes>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Companies-------------------------------");
                this.mLogger.Info((object)" Companies synchronization ");
                List<Companies> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Companies>("companies", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Companies>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------LaborCosts-------------------------------");
                this.mLogger.Info((object)" LaborCosts synchronization ");
                List<LaborCosts> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<LaborCosts>("laborcosts", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<LaborCosts>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------LaborRateScheduleBillingRates-------------------------------");
                this.mLogger.Info((object)" LaborRateScheduleBillingRates synchronization ");
                List<LaborRateScheduleBillingRates> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<LaborRateScheduleBillingRates>("laborrateschedulebillingrates", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<LaborRateScheduleBillingRates>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------LaborRateSchedules-------------------------------");
                this.mLogger.Info((object)" LaborRateSchedules synchronization ");
                List<LaborRateSchedules> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<LaborRateSchedules>("laborrateschedules", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<LaborRateSchedules>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------OtherCosts-------------------------------");
                this.mLogger.Info((object)" OtherCosts synchronization ");
                List<OtherCosts> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<OtherCosts>("othercosts", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<OtherCosts>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------PriorityTypeSlaDetails-------------------------------");
                this.mLogger.Info((object)" PriorityTypeSlaDetails synchronization ");
                List<PriorityTypeSlaDetails> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<PriorityTypeSlaDetails>("prioritytypesladetails", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<PriorityTypeSlaDetails>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Properties-------------------------------");
                this.mLogger.Info((object)" Properties synchronization ");
                List<Properties> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Properties>("properties", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Properties>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------RegionRegionAssociations-------------------------------");
                this.mLogger.Info((object)" RegionRegionAssociations synchronization ");
                List<RegionRegionAssociations> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<RegionRegionAssociations>("regionregionassociations", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<RegionRegionAssociations>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Regions-------------------------------");
                this.mLogger.Info((object)" Regions synchronization ");
                List<Regions> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Regions>("regions", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Regions>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Schedules-------------------------------");
                this.mLogger.Info((object)" Schedules synchronization ");
                List<Schedules> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Schedules>("schedules", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Schedules>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------ServiceTypes-------------------------------");
                this.mLogger.Info((object)" ServiceTypes synchronization ");
                List<ServiceTypes> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<ServiceTypes>("servicetypes", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<ServiceTypes>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Spaces-------------------------------");
                this.mLogger.Info((object)" Spaces synchronization ");
                List<Spaces> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Spaces>("spaces", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Spaces>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Users-------------------------------");
                this.mLogger.Info((object)" Users synchronization ");
                List<Users> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Users>("users", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Users>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                int skip = 0;
                Console.WriteLine("-------------------------------Workorders-------------------------------");
                this.mLogger.Info((object)"[sync] Workorders synchronization ");
                List<Workorders> result;
                do
                {
                    result = HttpHelper.GetEntitiesNew<Workorders>("workorders", skip).Result;
                    EntityHelper.AddUpdateEntitiesNew<Workorders>(result);
                    skip += result.Count;
                }
                while (result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
            try
            {
                Console.WriteLine("-------------------------------WorkOrderChargeToAccounts-------------------------------");
                this.mLogger.Info((object)"[sync] WorkOrderChargeToAccounts synchronization ");
                foreach (long ReqID in this.GetReId())
                    EntityHelper.AddUpdateEntitiesNew<WorkOrderChargeToAccounts>(HttpHelper.GetEntities_WorkOrderChargeToAccounts<WorkOrderChargeToAccounts>("workorderchargetoaccounts", ReqID).Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.mLogger.Error((object)string.Format("[sync] Error synchronization Exception: {0} Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
            }
        }

        private List<long> GetReId()
        {
            bool flag = false;
            List<long> reId = new List<long>();
            string[] strArray = File.ReadAllLines("WOReqId.txt");
            for (int index = 0; index < strArray.Length; ++index)
            {
                if (string.IsNullOrEmpty(strArray[index]))
                    flag = false;
                long result;
                if (!flag && long.TryParse(strArray[index + 2], out result))
                {
                    reId.Add(result);
                    flag = true;
                }
            }
            return reId;
        }
    }
}
