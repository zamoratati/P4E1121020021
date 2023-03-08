using CRUDSqlite.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace CRUDSqlite
{
    
    public partial class App : Application
    {
        static SQLiteHerper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static SQLiteHerper SQLiteDB
        {
            get
            {
                if (db==null)
                {
                    db = new SQLiteHerper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Eduardo.db3"));

                }
                return db;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
