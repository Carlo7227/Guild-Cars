namespace GuildCars.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int ModelsID { get; set; }

        public int? MakeID { get; set; }

        [Column("Model")]
        [Required]
        [StringLength(50)]
        public string Model1 { get; set; }

        public virtual Make Make { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
