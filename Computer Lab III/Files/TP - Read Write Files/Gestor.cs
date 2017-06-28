using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP___Read_Write_Files
{
    class Gestor
    {

        public void guardarArchivo(string ubicacion)
        {
            try
            {
                CustomersDataContext db = new CustomersDataContext();

                var cliente = from c in db.Customers
                              select c;

                StreamWriter writer = new StreamWriter(ubicacion);
                StringBuilder buffer = new StringBuilder();

                foreach (var c in cliente)
                {
                    buffer.Append(c.CustomerID + "\t" + c.CompanyName + "\t" + c.ContactName + "\t" + c.ContactTitle + "\t" + c.Address + "\t" + c.City + "\t" + c.Region + "\t" + c.PostalCode + "\t" + c.Country + "\t" + c.Phone + "\t" + c.Fax);
                    buffer.Append("\n");
                }                
                writer.Write(buffer.ToString());
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void leerArchivo(string ubicacion)
        {
            try
            {
                CustomersDataContext db = new CustomersDataContext();
                StreamReader reader = new StreamReader(ubicacion);
                string linea = reader.ReadLine();
                while(linea != null)
                {
                    string[] columnas = linea.Split('\t');

                    Customer cliente = new Customer();
                    cliente.CustomerID = "Z" + columnas[0].Remove(0, 1);
                    cliente.CompanyName = columnas[1];
                    cliente.ContactName = columnas[2];
                    cliente.ContactTitle = columnas[3];
                    cliente.Address = columnas[4];
                    cliente.City = columnas[5];
                    cliente.Region = columnas[6];
                    cliente.PostalCode = columnas[7];
                    cliente.Country = columnas[8];
                    cliente.Phone = columnas[9];
                    cliente.Fax = columnas[10];

                    db.Customers.InsertOnSubmit(cliente);
                    db.SubmitChanges();

                    linea = reader.ReadLine();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
