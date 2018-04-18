namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class werknemers
    {
        [Key]
        public int WERKNEMERID { get; set; }

        [Required]
        [StringLength(50)]
        public string GEBRUIKERSNAAM { get; set; }

        [Required]
        [StringLength(50)]
        public string WACHTWOORD { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(16)]
        public string TELEFOON { get; set; }
    }
}
