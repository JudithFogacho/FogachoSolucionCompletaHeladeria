using FogachoWebHeladeria.Models;
using Newtonsoft.Json;
namespace FogachoHeladeriaApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7165/api/");
            var response = client.GetAsync("aF_Helado").Result;

            if (response.IsSuccessStatusCode)
            {
                var helados = response.Content.ReadAsStringAsync().Result;
                var heladosList = JsonConvert.DeserializeObject<List<AF_Helado>>(helados);
                ListView.ItemsSource = heladosList;
            }
        }

    }

}
