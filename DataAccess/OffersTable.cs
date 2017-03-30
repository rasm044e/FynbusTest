namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.OffersTable")]
    public partial class OffersTable
    {
        [StringLength(50)]
        public string OfferReferenceNumber { get; set; }

        public int RouteID { get; set; }

        public double? OperationPrice { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string CreateRouteNumberPriority { get; set; }

        [StringLength(50)]
        public string CreateContractorPriority { get; set; }

        [Key]
        public int KeyID { get; set; }
    }
}
