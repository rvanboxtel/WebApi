using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public partial class SchipsViewModel : schips
    {
        [Required]
        [DisplayName("Nummer")]
        public override int NUMMER { get; set; }
        [Required]
        [Range(1, 3)]
        [DisplayName("Klasse")]
        public override int KLASSE { get; set; }

        [DisplayName("Naam")]
        public override string NAAM { get; set; }
        
        [DisplayName("Averij")]
        public override Boolean AVERIJ { get; set; }
        [Range(1, 3)]
        [DisplayName("Soortcode")]
        public override int SOORTCODE { get; set; }
    }
}
