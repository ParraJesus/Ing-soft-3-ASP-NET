using Ing_soft_3_ASP_MVC.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Ing_soft_3_ASP_MVC.Datos
{
    public class EstudianteDatos
    {
        public List<EstudianteModel> Listar()
        {
            var oLista = new List<EstudianteModel>();
            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string query = "SELECT Estudiante_id, Nombre, Apellido FROM Estudiante";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new EstudianteModel()
                            {
                                Estudiante_id = Convert.ToInt32(dr["Estudiante_id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString()
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        public EstudianteModel Obtener(int Estudiante_id)
        {
            var oEstudiante = new EstudianteModel();
            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string query = "SELECT Estudiante_id, Nombre, Apellido FROM Estudiante WHERE Estudiante_id = @Estudiante_id";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Estudiante_id", Estudiante_id);
                    cmd.CommandType = CommandType.Text;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oEstudiante.Estudiante_id = Convert.ToInt32(dr["Estudiante_id"]);
                            oEstudiante.Nombre = dr["Nombre"].ToString();
                            oEstudiante.Apellido = dr["Apellido"].ToString();
                        }
                    }
                }
            }

            return oEstudiante;
        }

        public bool Guardar(EstudianteModel oEstudiante)
        {
            bool guardado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "INSERT INTO Estudiante (Nombre, Apellido) VALUES (@Nombre, @Apellido)";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", oEstudiante.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", oEstudiante.Apellido);
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

        public bool Editar(EstudianteModel oEstudiante)
        {
            bool editado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "UPDATE Estudiante SET Nombre = @Nombre, Apellido = @Apellido WHERE Estudiante_id = @Estudiante_id";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Estudiante_id", oEstudiante.Estudiante_id);
                        cmd.Parameters.AddWithValue("@Nombre", oEstudiante.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", oEstudiante.Apellido);
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

        public bool Eliminar(int Estudiante_id)
        {
            bool eliminado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "DELETE FROM Estudiante WHERE Estudiante_id = @Estudiante_id";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Estudiante_id", Estudiante_id);
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