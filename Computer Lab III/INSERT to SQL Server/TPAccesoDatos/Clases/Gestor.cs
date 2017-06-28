using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPAccesoDatos.Clases;

namespace TPAccesoDatos.Clases
{
    class Gestor
    {
        Conexion con = new Conexion();
        SqlCommand cmd = null;

        public DataTable mostrarTabla()
        {
            try
            {
                String query = "SELECT * FROM authors";
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


        public void insertarAuthor(Author author)
        {
            string query = "INSERT INTO Authors (au_id, au_lname, au_fname, phone, address, city, state, zip, contract)" +
                           " VALUES (@id, @apellido, @nombre, @telefono, @direccion, @ciudad, @provincia, @codigoPostal, @contrato)";

            try
            {
                cmd = new SqlCommand(query, con.conectar());
                cmd.Parameters.AddWithValue("@id", author.Id);
                cmd.Parameters.AddWithValue("@apellido", author.Apellido);
                cmd.Parameters.AddWithValue("@nombre", author.Nombre);
                cmd.Parameters.AddWithValue("@telefono", author.Telefono);
                cmd.Parameters.AddWithValue("@direccion", author.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", author.Ciudad);
                cmd.Parameters.AddWithValue("@provincia", author.Provincia);
                cmd.Parameters.AddWithValue("@codigoPostal", author.CodigoPostal);
                cmd.Parameters.AddWithValue("@contrato", author.Contrato);
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
