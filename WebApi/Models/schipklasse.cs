namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("schipklasse")]
    public partial class schipklasse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public schipklasse()
        {
            schip = new HashSet<schip>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KLASSEID { get; set; }

        [StringLength(50)]
        public string NAAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<schip> schip { get; set; }
    }
}
