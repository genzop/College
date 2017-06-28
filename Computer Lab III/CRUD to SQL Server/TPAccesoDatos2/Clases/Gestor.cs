using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAccesoDatos2.Clases
{
    class Gestor
    {
        Conexion con = new Conexion();
        SqlCommand cmd = null;

        public DataTable mostrarTabla()
        {
            try
            {
                String query = "SELECT * FROM publishers";
                cmd = new SqlCommand(query, con.conectar());
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            finally
            {
                con.desconectar();
            }
        }

        public void insertar(Publisher publisher)
        {
            string query = "INSERT INTO publishers (pub_id, pub_name, city, state, country)" +
                         "VALUES (@id, @nombre, @ciudad, @provincia, @pais)";

            try
            {
                cmd = new SqlCommand(query, con.conectar());
                cmd.Parameters.AddWithValue("@id", publisher.Id);
                cmd.Parameters.AddWithValue("@nombre", publisher.Nombre);
                cmd.Parameters.AddWithValue("@ciudad", publisher.Ciudad);
                cmd.Parameters.AddWithValue("@provincia", publisher.Provincia);
                cmd.Parameters.AddWithValue("@pais", publisher.Pais);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                con.desconectar();
            }
        }

        public void modificar(Publisher publisher)
        {
            string query = "UPDATE publishers SET pub_name = @nombre, city = @ciudad, state = @provincia, country = @pais WHERE pub_id = @id";

            try
            {
                cmd = new SqlCommand(query, con.conectar());
                cmd.Parameters.AddWithValue("@nombre", publisher.Nombre);
                cmd.Parameters.AddWithValue("@ciudad", publisher.Ciudad);
                cmd.Parameters.AddWithValue("@provincia", publisher.Provincia);
                cmd.Parameters.AddWithValue("@pais", publisher.Pais);
                cmd.Parameters.AddWithValue("@id", publisher.Id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                con.desconectar();
            }
        }

        public void eliminar(Publisher publisher)
        {
            string query = "DELETE FROM publishers WHERE pub_id = @id";

            try
            {
                cmd = new SqlCommand(query, con.conectar());
                cmd.Parameters.AddWithValue("@id", publisher.Id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                con.desconectar();
            }
        }
    }
}
