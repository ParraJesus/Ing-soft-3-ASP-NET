using Ing_soft_3_ASP_MVC.Models;
using System.Data.SQLite;
using System.Data;

namespace Ing_soft_3_ASP_MVC.Datos
{
    public class EstudianteCursoDatos
    {
        public List<EstudianteCursoModel> Listar()
        {
            var oLista = new List<EstudianteCursoModel>();
            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string query = "SELECT Estudiante_id, Curso_id FROM Estudiante_Curso";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new EstudianteCursoModel()
                            {
                                Estudiante_id = Convert.ToInt32(dr["Estudiante_id"]),
                                Curso_id = Convert.ToInt32(dr["Curso_id"])
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        public EstudianteCursoModel Obtener(int estudianteId, int cursoId)
        {
            var oEstudianteCurso = new EstudianteCursoModel();
            var cn = new Conexion();

            using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string query = "SELECT Estudiante_id, Curso_id FROM Estudiante_Curso WHERE Estudiante_id = @Estudiante_id AND Curso_id = @Curso_id";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Estudiante_id", estudianteId);
                    cmd.Parameters.AddWithValue("@Curso_id", cursoId);
                    cmd.CommandType = CommandType.Text;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oEstudianteCurso.Estudiante_id = Convert.ToInt32(dr["Estudiante_id"]);
                            oEstudianteCurso.Curso_id = Convert.ToInt32(dr["Curso_id"]);
                        }
                    }
                }
            }

            return oEstudianteCurso;
        }

        public bool Guardar(EstudianteCursoModel oEstudianteCurso)
        {
            bool guardado;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "INSERT INTO Estudiante_Curso (Estudiante_id, Curso_id) VALUES (@Estudiante_id, @Curso_id)";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Estudiante_id", oEstudianteCurso.Estudiante_id);
                        cmd.Parameters.AddWithValue("@Curso_id", oEstudianteCurso.Curso_id);
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

        public bool Eliminar(int estudianteId, int cursoId)
        {
            bool eliminado;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SQLiteConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    string query = "DELETE FROM Estudiante_Curso WHERE Estudiante_id = @Estudiante_id AND Curso_id = @Curso_id";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Estudiante_id", estudianteId);
                        cmd.Parameters.AddWithValue("@Curso_id", cursoId);
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
