namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cursus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cursus()
        {
            cursist = new HashSet<cursist>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CURSUSCODE { get; set; }

        public DateTime? BEGINDATUM { get; set; }

        public DateTime? EINDDATUM { get; set; }

        public int? SOORTCODE { get; set; }

        public virtual soortcursus soortcursus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cursist> cursist { get; set; }
    }
}
