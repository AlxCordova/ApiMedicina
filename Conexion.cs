using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedicina
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options) : base(options) { }
        public DbSet<E_Medicina> Medicina { get; set; }
    }

    public class Conectar
    {
        private const string conexion = "Server=mysql-umg.mysql.database.azure.com; Port=3306; database=CLINICA; Uid=umg_desarrollo@mysql-umg; Pwd=$D3v_Web;";
        public static Conexion GetConexion()
        {
            var builder = new DbContextOptionsBuilder<Conexion>();
            builder.UseMySQL(conexion);
            return new Conexion(builder.Options);
        }
    }
}
