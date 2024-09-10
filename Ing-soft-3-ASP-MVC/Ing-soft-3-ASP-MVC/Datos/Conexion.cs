using System.Data.SQLite;

namespace Ing_soft_3_ASP_MVC.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL() 
        {
            return cadenaSQL;
        }
    }
}
