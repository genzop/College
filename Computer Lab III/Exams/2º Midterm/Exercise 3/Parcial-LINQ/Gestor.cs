using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_LINQ
{
    class Gestor
    {

        NorthwindDataContext db = new NorthwindDataContext();

        public void puntoA()
        {
            var puntoA = from emp in db.Employees
                         select new
                         {
                             LastName = emp.LastName,
                             FirstName = emp.FirstName,
                             Address = emp.Address,
                             City = emp.City,
                         };

            var aOrdenados = from emp in puntoA
                             group emp by emp.City;

            foreach (var grupos in aOrdenados)
            {
                Console.WriteLine(grupos.Key);
                foreach (var emp in grupos)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Address + " " + emp.City);
                }
                Console.WriteLine("\n");
            }
                                     
        }

        public void puntoB()
        {
            var puntoB = (from prod in db.Products
                          select Convert.ToInt32(prod.UnitsOnOrder)).Average();
            
        }

        public void puntoC()
        {
            Shipper shipper = new Shipper();
            shipper.CompanyName = "Informac";
            shipper.Phone = "(503)555-9831";
            db.Shippers.InsertOnSubmit(shipper);
            db.SubmitChanges();
        }

        public void puntoD()
        {
            var eliminar = (from ship in db.Shippers
                           where ship.CompanyName == "Informac"
                           select ship).Single();
            db.Shippers.DeleteOnSubmit(eliminar);
            db.SubmitChanges();
        }


    }
}
