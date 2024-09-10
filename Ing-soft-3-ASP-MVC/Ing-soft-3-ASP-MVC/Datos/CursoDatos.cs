using Ing_soft_3_ASP_MVC.Models;
using System.Data;
using System.Data.SQLite;

namespace Ing_soft_3_ASP_MVC.Datos
{
    public class CursoDatos
    {
        public List<CursoModel> Listar()
        {
            var oLista = new List<CursoModel>();
            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string query = "SELECT Curso_id, Nombre, Profesor_id FROM Curso";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new CursoModel()
                            {
                                Curso_id = Convert.ToInt32(dr["Curso_id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Profesor_id = Convert.ToInt32(dr["Profesor_id"])
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        public CursoModel Obtener(int Curso_id)
        {
            var oCurso = new CursoModel();
            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string query = "SELECT Curso_id, Nombre, Profesor_id FROM Curso WHERE Curso_id = @Curso_id";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Curso_id", Curso_id);
                    cmd.CommandType = CommandType.Text;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCurso.Curso_id = Convert.ToInt32(dr["Curso_id"]);
                            oCurso.Nombre = dr["Nombre"].ToString();
                            oCurso.Profesor_id = Convert.ToInt32(dr["Profesor_id"]);
                        }
                    }
                }
            }

            return oCurso;
        }

        public bool Guardar(CursoModel oCurso)
        {
            bool guardado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "INSERT INTO Curso (Nombre, Profesor_id) VALUES (@Nombre, @Profesor_id)";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", oCurso.Nombre);
                        cmd.Parameters.AddWithValue("@Profesor_id", oCurso.Profesor_id);
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

        public bool Editar(CursoModel oCurso)
        {
            bool editado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "UPDATE Curso SET Nombre = @Nombre, Profesor_id = @Profesor_id WHERE Curso_id = @Curso_id";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Curso_id", oCurso.Curso_id);
                        cmd.Parameters.AddWithValue("@Nombre", oCurso.Nombre);
                        cmd.Parameters.AddWithValue("@Profesor_id", oCurso.Profesor_id);
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

        public bool Eliminar(int Curso_id)
        {
            bool eliminado;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "DELETE FROM Curso WHERE Curso_id = @Curso_id";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Curso_id", Curso_id);
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
