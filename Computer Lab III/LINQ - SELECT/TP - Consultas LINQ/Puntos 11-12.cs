using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP___Consultas_LINQ
{
    class Puntos_11_12
    {
        NorthwindDataContext db = new NorthwindDataContext();

        public void punto11()
        {
            var punto11 = from cust in db.Customers
                          group cust by cust.City;

            foreach (var grupoCust in punto11)
            {
                Console.WriteLine(grupoCust.Key);
                foreach (Customer customer in grupoCust)
                {
                    Console.WriteLine(customer.CustomerID + "   " + customer.CompanyName + "   " + customer.ContactName + "   " + customer.ContactTitle + "   " + customer.Address + "   " + customer.City + "   " + customer.Region + "   " + customer.PostalCode + "   " + customer.Country + "   " + customer.Phone + "   " + customer.Fax + "\n");                    
                }
                Console.WriteLine("\n");
            }
        }
        public void punto12()
        {
            var punto12_1 = (from prod in db.Products
                          where prod.UnitPrice > 0
                          select prod.UnitPrice).Count();            
            Console.WriteLine("Hay " + punto12_1 + " registros");

            var punto12_2 = (from prod in db.Products
                            where prod.UnitPrice > 0
                            select prod.UnitPrice).Max();
            Console.WriteLine("El valor máximo es " + punto12_2);

            var punto12_3 = (from prod in db.Products
                             where prod.UnitPrice > 0
                             select prod.UnitPrice).Average();
            Console.WriteLine("El promedio es " + punto12_3);

            var punto12_4 = (from prod in db.Products
                             where prod.UnitPrice > 0
                             select prod.UnitPrice).First();
            Console.WriteLine("El primer valor es " + punto12_4);
        }
    }
}
