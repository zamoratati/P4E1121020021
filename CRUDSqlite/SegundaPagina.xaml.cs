using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDSqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegundaPagina : ContentPage
    {
        public SegundaPagina(int latitud, int longitud, string descripcion, string descripcioncorta)
        {
            InitializeComponent();
            segundapagina.Text = "Latitud:  " + latitud  + "  Longitud:  " + longitud + "  Descripcion Larga:  " + descripcion +"  Descripcion Corta:  " + descripcioncorta;
            
        }
    }
}