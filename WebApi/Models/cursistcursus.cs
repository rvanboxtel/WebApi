using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class cursistcursus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CURSUSCODE { get; set; }
        public string EMAILADRES { get; set; }
    }
}
