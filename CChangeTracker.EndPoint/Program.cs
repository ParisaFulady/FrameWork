using AChangeTracker.Entities;
using BChangeTracker.DAL;
using System;

namespace CChangeTracker.EndPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new TeacherContext();
            add(ctx);
        }
        private static void add(TeacherContext ctx)
        {
            ctx.Teachers.Add(new Teachers
            {
                FirstName = "ي",
                LastName = "نیکا"

            });

            ctx.SaveChanges();
        }
    }
}
