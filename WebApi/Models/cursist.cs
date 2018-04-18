namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cursist")]
    public partial class cursist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cursist()
        {
            cursus = new HashSet<cursus>();
        }

        [Key]
        [StringLength(45)]
        public string EMAILADRES { get; set; }

        [StringLength(45)]
        public string ROEPNAAM { get; set; }

        [StringLength(45)]
        public string TUSSENVOEGSEL { get; set; }

        [StringLength(45)]
        public string ACHTERNAAM { get; set; }

        [StringLength(45)]
        public string ADRES { get; set; }

        [StringLength(45)]
        public string WOONPLAATS { get; set; }

        [StringLength(16)]
        public string TELEFOON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cursus> cursus { get; set; }
    }
}
