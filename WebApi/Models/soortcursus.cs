using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class soortcursus
    {
        [Key]
        public int SOORTCODE { get; set; }
        public string CURSUSSOORT { get; set; }
        public Double PRIJS { get; set; }
    }
}
