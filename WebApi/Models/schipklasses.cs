using System;
using Dapper;

namespace WebApi.Models
{
    public class schipklasses
    {
        [Key]
        public int KLASSEID { get; set; }
        public string NAAM { get; set; }
    }
}
