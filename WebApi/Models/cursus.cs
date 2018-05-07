using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class cursus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CURSUSCODE { get; set; }
        public DateTime BEGINDATUM { get; set; }
        public DateTime EINDDATUM { get; set; }
        public int SOORTCODE { get; set; }
    }
}
