using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CRUDSqlite.Models;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace CRUDSqlite.Data
{
    public class SQLiteHerper
    {
        SQLiteAsyncConnection db;
        public SQLiteHerper(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath); 
            db.CreateTableAsync<Localizacion>().Wait();
        }
        /// <summary>
        /// Guarda la localizacion
        /// </summary>
        /// <param name="locali"></param>
        /// <returns></returns>
        public Task<int> SaveLicalizacionAsync(Localizacion locali)
        {
            if (locali.idLocalizacion!=0)
            {
                return db.UpdateAsync(locali);

            }
            else
            {
                return db.InsertAsync(locali);
            }
        }
        /// <summary>
        /// Muestra los registros agregados
        /// </summary>
        /// <returns></returns>
        public Task<List<Localizacion>> GetLocalizacionAsync()
        {
            return db.Table<Localizacion>().ToListAsync();

        }
        /// <summary>
        /// recuperar la Localizacion por 
        /// </summary>
        /// <param name="IdLocalizacion"></param>
        /// <returns></returns>
        public Task<Localizacion> GetLocalizacionByidAsync(int IdLocalizacion)
        {
            return db.Table<Localizacion>().Where(a =>a.idLocalizacion == IdLocalizacion).FirstOrDefaultAsync();

        }

        public Task<int> DeleteubicacionAsync(Localizacion localizacion)
        {
            return db.DeleteAsync(localizacion);
        }
    }
}
