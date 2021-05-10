using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    public class MyDbContext:DbContext
    {
        //数据库连接
        public MyDbContext() : base("name=conn1")
        {

        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //实体映射
            modelBuilder.Entity<Person>().ToTable("T_Persons");
        }
    }
}
