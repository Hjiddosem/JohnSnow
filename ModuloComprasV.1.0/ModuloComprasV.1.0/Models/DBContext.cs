using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ModuloComprasV._1._0.Models
{
    public class DBContext : DbContext
    {
        public DbSet<CuentaDeUsuario> Compras { get; set; }
    }
}