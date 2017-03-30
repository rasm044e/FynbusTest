namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.ContractorsTable")]
    public partial class ContractorsTable
    {
        [StringLength(50)]
        public string ReferenceNumberBasicInformationPDF { get; set; }

        [StringLength(50)]
        public string ManagerName { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string TryParseValueType2PledgedVehicles { get; set; }

        [StringLength(50)]
        public string TryParseValueType3PledgedVehicles { get; set; }

        [StringLength(50)]
        public string TryParseValueType5PledgedVehicles { get; set; }

        [StringLength(50)]
        public string TryParseValueType6PledgedVehicles { get; set; }

        [StringLength(50)]
        public string TryParseValueType7PledgedVehicles { get; set; }

        [Key]
        public int KeyID { get; set; }
    }
}
