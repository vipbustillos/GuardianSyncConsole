using GuardianSyncConsole.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace GuardianSyncConsole.Services
{
    public class EntityHelper
    {
        public static void AddUpdateEntities<T>(List<T> entitiesAPI, List<T> entities) where T : IEntityId
        {
            ILog logger = LogManager.GetLogger("servicelog");
            try
            {
                foreach (T obj1 in entitiesAPI)
                {
                    T entity = obj1;
                    try
                    {
                        T obj2 = entities.FirstOrDefault<T>((Func<T, bool>)(c => c.Id == entity.Id));
                        if ((object)obj2 == null)
                        {
                            EntityHelper.AddEntity<T>(entity);
                        }
                        else
                        {
                            DateTime? updateDate1 = obj2.UpdateDate;
                            DateTime? updateDate2 = entity.UpdateDate;
                            if ((updateDate1.HasValue == updateDate2.HasValue ? (updateDate1.HasValue ? (updateDate1.GetValueOrDefault() != updateDate2.GetValueOrDefault() ? 1 : 0) : 0) : 1) != 0)
                                EntityHelper.UpdateEntity<T>(entity);
                        }
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult entityValidationError in ex.EntityValidationErrors)
                        {
                            logger.Info((object)string.Format("Entity of type [{0}] in state [{1}] has the following validation errors:", (object)entityValidationError.Entry.Entity.GetType().Name, (object)entityValidationError.Entry.State));
                            foreach (DbValidationError validationError in (IEnumerable<DbValidationError>)entityValidationError.ValidationErrors)
                                logger.Info((object)("- Property: [" + validationError.PropertyName + "], Error: [" + validationError.ErrorMessage + "]"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddUpdateEntitiesNew<T>(List<T> entitiesAPI) where T : IEntityId
        {
            ILog logger = LogManager.GetLogger("servicelog");
            try
            {
                foreach (T obj1 in entitiesAPI)
                {
                    try
                    {
                        using (GuardianStagingEntities guardianStagingEntities = new GuardianStagingEntities())
                        {
                            T obj2 = (T)guardianStagingEntities.Set(obj1.GetType()).Find(new object[1]
                            {
                (object) obj1.Id
                            });
                            if ((object)obj2 == null)
                            {
                                guardianStagingEntities.Set(obj1.GetType()).Add((object)obj1);
                                guardianStagingEntities.SaveChanges();
                                logger.Info((object)string.Format("[AddUpdateEntitiesNew] [{0}] was added with Id [{1}]", (object)typeof(T).Name, (object)obj1.Id));
                                Console.WriteLine(string.Format("[AddUpdateEntitiesNew] [{0}] was added with Id [{1}]", (object)typeof(T).Name, (object)obj1.Id));
                            }
                            else
                            {
                                DateTime? updateDate1 = obj2.UpdateDate;
                                DateTime? updateDate2 = obj1.UpdateDate;
                                if ((updateDate1.HasValue == updateDate2.HasValue ? (updateDate1.HasValue ? (updateDate1.GetValueOrDefault() != updateDate2.GetValueOrDefault() ? 1 : 0) : 0) : 1) != 0)
                                {
                                    guardianStagingEntities.Entry((object)obj2).CurrentValues.SetValues((object)obj1);
                                    guardianStagingEntities.SaveChanges();
                                    logger.Info((object)string.Format("[AddUpdateEntitiesNew] [{0}] was update with Id [{1}]", (object)typeof(T).Name, (object)obj1.Id));
                                    Console.WriteLine(string.Format("[AddUpdateEntitiesNew] [{0}] was update with Id [{1}]", (object)typeof(T).Name, (object)obj1.Id));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error((object)string.Format("[AddUpdateEntitiesNew] Error1: [{0}] Inner[{1}]", (object)ex.Message, (object)ex.InnerException));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error((object)("[AddUpdateEntitiesNew] Error2: [" + ex.Message + "]"));
            }
        }

        private static void AddEntity<T>(T entity) where T : IEntityId
        {
            Console.WriteLine(string.Format("[{0}] would be added with id [{1}]", (object)typeof(T).Name, (object)entity.Id));
            ILog logger = LogManager.GetLogger("servicelog");
            using (GuardianStagingEntities guardianStagingEntities = new GuardianStagingEntities())
            {
                guardianStagingEntities.Database.Connection.Open();
                guardianStagingEntities.Set(entity.GetType()).Add((object)entity);
                guardianStagingEntities.SaveChanges();
            }
            logger.Info((object)string.Format("[{0}] was added with id [{1}]", (object)typeof(T).Name, (object)entity.Id));
        }

        private static void UpdateEntity<T>(T entity) where T : IEntityId
        {
            ILog logger = LogManager.GetLogger("servicelog");
            using (GuardianStagingEntities guardianStagingEntities = new GuardianStagingEntities())
            {
                object obj = guardianStagingEntities.Set(entity.GetType()).Find(new object[1]
                {
          (object) entity.Id
                });
                guardianStagingEntities.Entry(obj).CurrentValues.SetValues((object)entity);
                guardianStagingEntities.SaveChanges();
            }
            logger.Info((object)string.Format("[{0}] was updated with id [{1}]", (object)typeof(T).Name, (object)entity.Id));
        }
    }
}
