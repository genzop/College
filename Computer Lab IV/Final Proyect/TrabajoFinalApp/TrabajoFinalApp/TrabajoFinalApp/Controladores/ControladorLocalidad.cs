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
    public class ControladorLocalidad : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorLocalidad()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Localidades.db3"));
            conexion.CreateTable<Localidad>();
        }

        public void Insert(Localidad loc)
        {
            conexion.Insert(loc);
        }

        public void Update(Localidad loc)
        {
            conexion.Update(loc);
        }

        public void Delete(Localidad loc)
        {
            conexion.Delete(loc);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Localidad>();
        }

        public Localidad FindById(int id)
        {
            var localidad = (from loc in conexion.Table<Localidad>()
                             where loc.IdLocalidad == id
                             select loc).FirstOrDefault();
            return localidad;
        }

        public Localidad FindLast()
        {
            var localidad = (from loc in conexion.Table<Localidad>()
                             orderby loc.IdLocalidad
                             select loc).LastOrDefault();
            return localidad;
        }

        public List<Localidad> ShowAll()
        {
            var localidades = (from loc in conexion.Table<Localidad>()
                               orderby loc.IdLocalidad
                               select loc).ToList();
            return localidades;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
