using CRUDSqlite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDSqlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            llenardatos();
        }

        private void btnnuevaubicacion_Clicked(object sender, EventArgs e)
        {

        }

        private void btnubicacionessalvadas_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnsalvarubicacion_Clicked(object sender, EventArgs e)
        {
            if (validardatos())
            {
                Localizacion locali = new Localizacion
                { 
                    longitud = int.Parse(txtlongitud.Text),
                    latitud=int.Parse(txtlatitud.Text),
                    descripcionlarga=txtdescripcionlarga.Text,
                    descripcioncorta=txtdescripcioncorta.Text,
                };
                await App.SQLiteDB.SaveLicalizacionAsync(locali);
                Limpiarcontroles();
                await DisplayAlert("Registro", "Registro agregado exitosamente", "ok");
                llenardatos();
                Limpiarcontroles();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "ok");
            }
        }
        public async void llenardatos()
        {
            var Localizacionlist = await App.SQLiteDB.GetLocalizacionAsync();
            if (Localizacionlist != null)
            {
                LstLocalizaciones.ItemsSource = Localizacionlist;

            }
        }
        public bool validardatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtlongitud.Text))
            {
                respuesta= false;
            }
            if (string.IsNullOrEmpty(txtlatitud.Text))
            {
                respuesta = false;
            }
            if (string.IsNullOrEmpty(txtdescripcionlarga.Text))
            {
                respuesta = false;
            }
            if (string.IsNullOrEmpty(txtdescripcioncorta.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta=true;
            }
            return respuesta;
        }

        private async void btnActubicacion_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtidLocalizacion.Text))
            {
                Localizacion localizacion = new Localizacion()
                {
                    idLocalizacion = Convert.ToInt32(txtidLocalizacion.Text),
                    latitud = Convert.ToInt32( txtlatitud.Text),
                    longitud =Convert.ToInt32( txtlongitud.Text),
                    descripcionlarga = txtdescripcionlarga.Text,
                    descripcioncorta = txtdescripcioncorta.Text,
                };
                await App.SQLiteDB.SaveLicalizacionAsync(localizacion);
                await DisplayAlert("Registro", "se actualizaron de manera exitosa los datos", "ok");
                txtidLocalizacion.Text = "";
                txtlatitud.Text = "";
                txtlongitud.Text = "";
                txtdescripcionlarga.Text = "";
                txtdescripcioncorta.Text = "";
                txtidLocalizacion.IsVisible = false;
                btnActubicacion.IsVisible=false;
                btnsalvarubicacion.IsVisible=true;
                llenardatos();
            }

        }       

        private async void LstLocalizaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Localizacion)e.SelectedItem;
            btnsalvarubicacion.IsVisible = false;
            txtidLocalizacion.IsVisible = true;
            btnActubicacion.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.idLocalizacion.ToString()))
            {
                var Locali = await App.SQLiteDB.GetLocalizacionByidAsync(obj.idLocalizacion);
                if (Locali != null)
                {
                    txtidLocalizacion.Text = Locali.idLocalizacion.ToString();
                    txtlatitud.Text=Locali.latitud.ToString();      
                    txtlongitud.Text=Locali.longitud.ToString();
                    txtdescripcioncorta.Text = Locali.descripcioncorta;
                    txtdescripcionlarga.Text= Locali.descripcionlarga;

                }
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var localizacion = await App.SQLiteDB.GetLocalizacionByidAsync(Convert.ToInt32(txtidLocalizacion.Text));
            if (localizacion != null)
            {
                await App.SQLiteDB.DeleteubicacionAsync(localizacion);
                await DisplayAlert("Localizacion", "Se elimino de manera exitosa", "ok");
                Limpiarcontroles();
                llenardatos();
                txtidLocalizacion.IsVisible = false;
                btnActubicacion.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnsalvarubicacion.IsVisible = true;
            }
        }
        public void Limpiarcontroles()
        {
            txtidLocalizacion.Text = "";
            txtlatitud.Text = "";
            txtlongitud.Text = "";
            txtdescripcionlarga.Text = "";
            txtdescripcioncorta.Text = "";
        }

        private async void btnsegund_Clicked(object sender, EventArgs e)
        {
            int latitud = int.Parse(txtlatitud.Text);
            int longitud = int.Parse(txtlongitud.Text);
            string descripcion = txtdescripcionlarga.Text;
            string descripcioncorta = txtdescripcioncorta.Text;
            await Application.Current.MainPage.Navigation.PushModalAsync(new SegundaPagina ( latitud, longitud, descripcion, descripcioncorta ));
            

        }
    }



}
