﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class schipklasses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int KLASSEID { get; set; }
        public string NAAM { get; set; }
    }
}
