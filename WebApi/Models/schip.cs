namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("schip")]
    public partial class schip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NUMMER { get; set; }

        public int? KLASSE { get; set; }

        [StringLength(45)]
        public string NAAM { get; set; }

        public byte AVERIJ { get; set; }

        public int? SOORTCODE { get; set; }

        public virtual soortcursus soortcursus { get; set; }

        public virtual schipklasse schipklasse { get; set; }
    }
}
