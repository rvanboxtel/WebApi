using System;
using Dapper;

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
