using Ing_soft_3_ASP_MVC.Models;
using System.Data.SQLite;
using System.Data;

namespace Ing_soft_3_ASP_MVC.Datos
{
    public class ProfesorDatos
    {
        public List<ProfesorModel> Listar()
        {

            var oLista = new List<ProfesorModel>();

            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                string query = "SELECT Profesor_id, Nombre, Apellido FROM Profesor";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new ProfesorModel()
                            {
                                Profesor_id = Convert.ToInt32(dr["Profesor_id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString()
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        public ProfesorModel Obtener(int Profesor_id)
        {
            var oProfesor = new ProfesorModel();
            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string query = "SELECT Profesor_id, Nombre, Apellido FROM Profesor WHERE Profesor_id = @Profesor_id";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Profesor_id", Profesor_id);
                    cmd.CommandType = CommandType.Text;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oProfesor.Profesor_id = Convert.ToInt32(dr["Profesor_id"]);
                            oProfesor.Nombre = dr["Nombre"].ToString();
                            oProfesor.Apellido = dr["Apellido"].ToString();
                        }
                    }
                }
            }

            return oProfesor;
        }

        public bool Guardar(ProfesorModel oProfesor)
        {
            bool guardado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    string query = "INSERT INTO Profesor (Nombre, Apellido) VALUES (@Nombre, @Apellido)";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", oProfesor.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", oProfesor.Apellido);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                guardado = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                guardado = false;
            }

            return guardado;
        }

        public bool Editar(ProfesorModel oProfesor)
        {
            bool editado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "UPDATE Profesor SET Nombre = @Nombre, Apellido = @Apellido WHERE Profesor_id = @Profesor_id";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Profesor_id", oProfesor.Profesor_id);
                        cmd.Parameters.AddWithValue("@Nombre", oProfesor.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", oProfesor.Apellido);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                editado = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                editado = false;
            }

            return editado;
        }

        public bool Eliminar(int Profesor_id)
        {
            bool eliminado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "DELETE FROM Profesor WHERE Profesor_id = @Profesor_id";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Profesor_id", Profesor_id);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                eliminado = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                eliminado = false;
            }

            return eliminado;
        }
    }
}
