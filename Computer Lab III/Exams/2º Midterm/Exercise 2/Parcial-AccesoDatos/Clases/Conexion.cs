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
    class Conexion
    {
        SqlConnection con = null;

        public SqlConnection conectar()
        {
            try
            {
                con = new SqlConnection("Data Source=GT-13-692;Initial Catalog=Almacen;Integrated Security=True");
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return null;
            }
        }

        public void desconectar()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
