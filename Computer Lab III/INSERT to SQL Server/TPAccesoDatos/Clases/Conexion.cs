using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAccesoDatos.Clases
{
    class Conexion
    {
        public SqlConnection con = null;

        public SqlConnection conectar()
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-SOMF6J6;Initial Catalog=pubs;Persist Security Info=True;User ID=admin;Password=admin");
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public bool desconectar()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

    }
}
