namespace GuildCars.Data
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Vehicle")]
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            Sales = new HashSet<Sale>();
        }

        public int VehicleID { get; set; }

        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        public int? ModelID { get; set; }

        public int? BodyTypeID { get; set; }

        public int? InteriorColorID { get; set; }

        public int? ExteriorColorID { get; set; }

        public bool IsAutomatic { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal MSRP { get; set; }

        public int? Mileage { get; set; }

        [Required]
        [StringLength(20)]
        public string VIN { get; set; }

        public int Year { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string ImageFileName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int IsNew { get; private set; }

        public bool? IsFeatured { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public virtual BodyType BodyType { get; set; }

        public virtual Color Color { get; set; }

        public virtual Color Color1 { get; set; }

        public virtual Model Model { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
