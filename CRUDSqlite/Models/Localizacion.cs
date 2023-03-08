using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUDSqlite.Models
{
    public class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int idLocalizacion { get; set; }
        [MaxLength(10)]
        public int latitud { get; set; }
        [MaxLength(10)]
        public int longitud { get; set; }

        [MaxLength(100)]
        public string descripcionlarga { get; set; }
        [MaxLength(50)]
        public string descripcioncorta { get; set; }

    }
}
