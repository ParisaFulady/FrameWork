using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BChangeTracker.DAL.Extentions
{
    public static class DbcontextExtention
    {

        public static bool ContainEntity<Tentity>(this DbContext dbContext) where Tentity : class
        {
            return dbContext.Model.FindEntityType(typeof(Tentity)) != null;
        }
        public static int Clear<Tentity>(this DbContext dbContext) where Tentity : class
        {
            return dbContext.ContainEntity<Tentity>() ? dbContext.Set<Tentity>().clear() : 0;
        }
        public static IEnumerable<EntityEntry> GetChangeEnities(this DbContext dbcontext, EntityState? entitystate = null)
        {
            var entities = dbcontext.ChangeTracker.Entries();
            if (entitystate.HasValue)
                entities = entities.Where(c => c.State == entitystate.Value);
            return entities;
        }
        public static IEnumerable<EntityEntry> GetModifiedEntities(this DbContext dbcontext)
        {
            return dbcontext.GetChangeEnities(EntityState.Modified);
        }
        public static IEnumerable<EntityEntry> GetDeletedEntities(this DbContext dbcontext)
        {
            return dbcontext.GetChangeEnities(EntityState.Deleted);

        }
        public static IEnumerable<EntityEntry> GetAddOrModifiedEntities(this DbContext dbcontext)
        {
            var entities = dbcontext.GetChangeEnities().Where(c => c.State == EntityState.Added || c.State == EntityState.Modified);
            return entities;
        }


    }
}
