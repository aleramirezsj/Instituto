using Modelos.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() : base("BibliotecaContext")
        {
            Database.SetInitializer<BibliotecaContext>(
              new MigrateDatabaseToLatestVersion<BibliotecaContext, Configuration>());
        }
    }
}
