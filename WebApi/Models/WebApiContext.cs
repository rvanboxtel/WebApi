using System;
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

        public System.Data.Entity.DbSet<WebApi.Models.schip> schips { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.schipklasse> schipklasses { get; set; }
    }
}
