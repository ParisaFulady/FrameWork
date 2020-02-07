using AChangeTracker.Entities;
using BChangeTracker.DAL.Extentions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BChangeTracker.DAL
{
    public abstract class BaseDbContext : DbContext
    {

        public override int SaveChanges()
        {
            BeforSave();
            var resualt = base.SaveChanges();
            AfterSave();
            return resualt;
        }

        private void AfterSave()
        {
        }
        private void BeforSave()
        {
            SetAduit();
            SetKey();
        }
        private void SetAduit()
        {
            var entities = ChangeTracker.Entries().Where(c => typeof(IAuditable).IsAssignableFrom(c.Entity.GetType()));
            LogContext logContext = new LogContext();
            foreach (var item in entities)
            {
                var temp = item.Entity as IAuditable;
                var Teacher = item.Entity as Teachers;
                if (item.State == EntityState.Added)
                {
                    temp.InsertBy = 1;
                    temp.InertDate = DateTime.Now;
                    temp.UpdateBy = 1;
                    temp.UpdateDate = DateTime.Now;
                }
                if (item.State == EntityState.Modified || item.State == EntityState.Added)
                {
                    temp.UpdateBy = 1;
                    temp.UpdateDate = DateTime.Now;
                    var serilaizeData = JsonConvert.SerializeObject(Teacher);

                    logContext.DataChangeHistory.Add(new DataChangeHistory
                    {
                        EtityID = Teacher.TeachersID.ToString(),
                        EntityType = Teacher.GetType().FullName,
                        RegistrationDate = DateTime.Now,
                        SerializeData = serilaizeData

                    });
                }

            }
            logContext.SaveChanges();
        }

        private void SetKey()
        {
            var deleteted = this.GetDeletedEntities();


            var AddedOrUpdated = this.GetAddOrModifiedEntities();
            foreach (var item in AddedOrUpdated)
            {
                var entity = item.Entity;
                if (item.Entity == null)
                {
                    continue;
                }
                var PropertyInfos = entity.GetType().GetProperties(
                    BindingFlags.Public | BindingFlags.Instance
                    ).Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
                foreach (var PropertyInfo in PropertyInfos)
                {
                    var PropName = PropertyInfo.Name;
                    var Value = PropertyInfo.GetValue(entity);
                    if (Value != null)
                    {
                        var strValue = Value.ToString();
                        var newValue = strValue.SetPersionYeKe();
                        if (newValue != strValue)
                        {
                            PropertyInfo.SetValue(entity, newValue);
                        }
                    }

                }
            }
        }
    }
}
