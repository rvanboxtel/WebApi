using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class soortcursus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int SOORTCODE { get; set; }
        public string CURSUSSOORT { get; set; }
        
    }
}
