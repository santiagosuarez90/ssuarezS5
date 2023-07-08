using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ssuarezS5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizarEliminar : ContentPage
	{
		public ActualizarEliminar (int codigo, string nombre, string apellido, int edad)
		{
            InitializeComponent();


            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();

		}

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                client.UploadValues("http://192.168.17.55/ws-uisrael/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                //DisplayAlert("Aviso", "Dato actualizado", "Cerrar");
                Navigation.PushAsync(new MainPage());
                DisplayAlert("ALERTA", "Dato Actualizado", "Cerrar");

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);


                cliente.UploadValues("http://192.168.17.55/ws-uisrael/post.php?codigo=" + txtCodigo.Text, "DELETE", parametros);
                DisplayAlert("ALERTA", "Dato Eliminado", "Cerrar");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }
    }
}