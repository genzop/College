using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_AccesoDatos.Clases
{
    class Gestor
    {

        Conexion con = new Conexion();
        SqlCommand cmd = null;

        public DataTable mostrarTabla()
        {
            try
            {
                string query = "SELECT * FROM articulo";
                cmd = new SqlCommand(query, con.conectar());
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return null;                
            }
            finally
            {
                con.desconectar();
            }
        }

        public void insertar(Articulo articulo)
        {
            string query = "INSERT INTO articulo (codigo, denominacion, rubro, stock) VALUES (@codigo, @denominacion, @rubro, @stock)";

            try
            {
                cmd = new SqlCommand(query, con.conectar());
                cmd.Parameters.AddWithValue("@codigo", articulo.Codigo);
                cmd.Parameters.AddWithValue("@denominacion", articulo.Denominacion);
                cmd.Parameters.AddWithValue("@rubro", articulo.Rubro);
                cmd.Parameters.AddWithValue("@stock", articulo.Stock);
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

        public void modificar(Articulo articulo)
        {
            string query = "UPDATE articulo SET denominacion = @denominacion, rubro = @rubro, stock = @stock WHERE codigo = @codigo";

            try
            {
                cmd = new SqlCommand(query, con.conectar());                
                cmd.Parameters.AddWithValue("@denominacion", articulo.Denominacion);
                cmd.Parameters.AddWithValue("@rubro", articulo.Rubro);
                cmd.Parameters.AddWithValue("@stock", articulo.Stock);
                cmd.Parameters.AddWithValue("@codigo", articulo.Codigo);
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

        public void eliminar(Articulo articulo)
        {
            string query = "DELETE FROM articulo WHERE codigo = @codigo";

            try
            {
                cmd = new SqlCommand(query, con.conectar());
                cmd.Parameters.AddWithValue("@codigo", articulo.Codigo);
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
