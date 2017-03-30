namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FynbusBackupModel : DbContext
    {
        public FynbusBackupModel()
            : base("name=FynbusBackupModel")
        {
        }

        public virtual DbSet<ContractorsTable> ContractorsTables { get; set; }
        public virtual DbSet<OffersTable> OffersTables { get; set; }
        public virtual DbSet<RouteNumbersTable> RouteNumbersTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
