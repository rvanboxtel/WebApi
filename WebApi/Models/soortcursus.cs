namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class soortcursus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public soortcursus()
        {
            cursus = new HashSet<cursus>();
            schip = new HashSet<schip>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOORTCODE { get; set; }

        [StringLength(45)]
        public string CURSUSSOORT { get; set; }

        public double? PRIJS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cursus> cursus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<schip> schip { get; set; }
    }
}
