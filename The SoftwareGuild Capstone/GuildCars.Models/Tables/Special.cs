namespace GuildCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Special
    {
        public int SpecialID { get; set; }

        [Required]
        [StringLength(30)]
        public string SpecialTitle { get; set; }

        [Required]
        [StringLength(300)]
        public string SpecialDescription { get; set; }

    }
}
