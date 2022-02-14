using System;

namespace GuardianSyncConsole
{
    //public interface IEntity<T>
    //{
    //    string AddEntity(T entity);
    //    string UpdateEntity(T entity);
    //}
    public interface IEntityId
    {
        long Id { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}