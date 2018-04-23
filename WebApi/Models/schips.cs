using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class schips
    {
        [Key]
        public int NUMMER { get; set; }
        public int KLASSE { get; set; }
        public string NAAM { get; set; }
        public Boolean AVERIJ { get; set; }
        public int SOORTCODE { get; set; }
    }
}
