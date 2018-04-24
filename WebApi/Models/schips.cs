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
    public partial class schips
    {
        [Key]
        public virtual int NUMMER { get; set; }
        public virtual int KLASSE { get; set; }
        public virtual string NAAM { get; set; }
        public virtual Boolean AVERIJ { get; set; }
        public virtual int SOORTCODE { get; set; }
    }
}
