using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class werknemers
    {
        
        public int WERKNEMERID { get; set; }
        [Key]
        public string GEBRUIKERSNAAM { get; set; }
        public string WACHTWOORD { get; set; }
        public string EMAIL { get; set; }
        public string TELEFOON { get; set; }
    }
}
