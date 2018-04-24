using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    /// <summary>
    /// A class which represents the schips table.
    /// </summary>
    [Table("schips")]
    public class schips
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int NUMMER { get; set; }
        public int KLASSE { get; set; }
        public string NAAM { get; set; }
        public Boolean AVERIJ { get; set; }
        public int SOORTCODE { get; set; }
    }
}
