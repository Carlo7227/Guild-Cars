namespace GuildCars.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Contact
    {
        public int ContactID { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public int? Phone { get; set; }

        [Required]
        [StringLength(750)]
        public string Message { get; set; }
    }
}
