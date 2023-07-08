using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ssuarezS5
{
    public partial class MainPage : ContentPage
    {
        private string url = "http://192.168.17.55/ws-uisrael/post.php";
        private HttpClient client = new HttpClient();
        private ObservableCollection<Estudiante> students;

        public MainPage()
        {
            InitializeComponent();

            loadStudents();
          
            var mensaje = "Elemento Insertado";

            DependencyService.Get<InterfaceToast>().longMessage(mensaje);
        }

        private void btnView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private async void loadStudents()
        {
            var contenido = await client.GetStringAsync(url);

            List<Estudiante> listStudents = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);

            students = new ObservableCollection<Estudiante>(listStudents);

            listStudent.ItemsSource = students;
        }

        private void listStudent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (Estudiante)e.SelectedItem;
            var codigoTem = objeto.codigo.ToString();
            int codigo = Convert.ToInt32(codigoTem);
            string nombre = objeto.nombre.ToString();
            string apellido = objeto.apellido.ToString();
            var edadTemp = objeto.edad.ToString();
            int edad = Convert.ToInt32(edadTemp);

            Navigation.PushAsync(new ActualizarEliminar(codigo, nombre, apellido, edad));
        }
    }
}
