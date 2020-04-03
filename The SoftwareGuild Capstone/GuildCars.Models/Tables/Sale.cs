namespace GuildCars.Data
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Sale
    {
        [Key]
        public int SalesID { get; set; }

        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        public int? VehicleID { get; set; }

        public int? PurchaseTypeID { get; set; }

        public int? StateID { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public int Phone { get; set; }

        public decimal PurchasePrice { get; set; }

        [Required]
        [StringLength(750)]
        public string Message { get; set; }

        [Required]
        [StringLength(50)]
        public string Street1 { get; set; }

        [StringLength(50)]
        public string Street2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public int ZipCode { get; set; }

        public virtual PurchaseType PurchaseType { get; set; }

        public virtual State State { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}




//redid the database this is its own table now

//[Required]
//[StringLength(2)]
//public string StateAbbreviation { get; set; }
