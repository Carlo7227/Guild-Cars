namespace GuildCars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        public int RoleID { get; set; }

        [Column("Role")]
        [Required]
        [StringLength(30)]
        public string Role1 { get; set; }
    }
}
