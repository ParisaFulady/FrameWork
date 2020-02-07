using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace BChangeTracker.DAL.Extentions
{
    public static class DbSetExtention
    {
        public static DbContext GetDbContext<TEnity>(this DbSet<TEnity> dbset) where TEnity : class
        {

            //In EntityFramework Core programming, You can get a DbContext object from a DbSet object like this:
            var infrastructure = dbset as IInfrastructure<IServiceProvider>;
            var serviceProvider = infrastructure.Instance;
            var currentDbContext = serviceProvider.GetService(typeof(ICurrentDbContext))
                                       as ICurrentDbContext;
            return currentDbContext.Context;
          }
        public static int clear<Tentity>(this DbSet<Tentity> dbset) where Tentity : class
        {
            var dcontext = dbset.GetDbContext();

            var relationalType = dcontext.Model.FindEntityType(typeof(Tentity));
            var schema = relationalType.GetSchema();
            var TableName = relationalType.GetTableName();
            string deletedCommand = $"deleted{schema}.{TableName}";
            var resualt = dcontext.Database.ExecuteSqlCommand(deletedCommand);
            return resualt;


        }
    }
}
