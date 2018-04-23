using System;
using Dapper;

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
