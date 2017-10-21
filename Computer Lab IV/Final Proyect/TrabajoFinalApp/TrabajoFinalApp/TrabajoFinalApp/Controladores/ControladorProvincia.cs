using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinalApp.Modelo;
using Xamarin.Forms;

namespace TrabajoFinalApp.Controladores
{
    public class ControladorProvincia : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorProvincia()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Provincias.db3"));
            conexion.CreateTable<Provincia>();
        }

        public void Insert(Provincia prov)
        {
            conexion.Insert(prov);
        }

        public void Update(Provincia prov)
        {
            conexion.Update(prov);
        }

        public void Delete(Provincia prov)
        {
            conexion.Delete(prov);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Provincia>();
        }

        public Provincia FindById(int id)
        {
            var provincia = (from prov in conexion.Table<Provincia>()
                             where prov.IdProvincia == id
                             select prov).FirstOrDefault();
            return provincia;
        }

        public Provincia FindLast()
        {
            var provincia = (from prov in conexion.Table<Provincia>()
                             orderby prov.IdProvincia
                             select prov).LastOrDefault();
            return provincia;
        }

        public List<Provincia> ShowAll()
        {
            var provincias = (from prov in conexion.Table<Provincia>()
                               orderby prov.IdProvincia
                               select prov).ToList();
            return provincias;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
