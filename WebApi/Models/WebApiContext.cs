﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WebApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApiContext() : base("name=WebApiContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<WebApi.Models.soortcursus> soortcursus { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.schips> schip { get; set; }
        public System.Data.Entity.DbSet<WebApi.Models.schipklasses> schipklasse { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.werknemers> werknemers { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.cursus> cursus { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.cursistcursus> cursistcursus { get; set; }
    }
}
