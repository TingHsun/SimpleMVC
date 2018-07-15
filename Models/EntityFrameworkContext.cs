using Models.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext() : base("EntityFramework")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<AutoMachineData> AutoMachineReport { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //自動產生資料表時不以複數規則命名
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
