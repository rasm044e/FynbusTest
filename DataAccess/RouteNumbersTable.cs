namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.RouteNumbersTable")]
    public partial class RouteNumbersTable
    {
        public int RouteID { get; set; }

        public int RequiredVehicleType { get; set; }

        [Key]
        public int KeyID { get; set; }
    }
}
