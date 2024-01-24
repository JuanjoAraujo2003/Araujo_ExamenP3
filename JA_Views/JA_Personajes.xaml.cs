using Araujo_ExamenP3.JA_Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Araujo_ExamenP3.JA_Views;

public partial class Personajes : ContentPage
{
	public Personajes()
	{
		InitializeComponent();
	}

    private void displayPerInformation(List<Root> personajes)
    {
        if (personajes != null && personajes.Any())
        {
            foreach (var personajeApi in personajes)
            {
                personajesLabel.Text += $"\n\nNombre del personaje: {personajeApi.name}\n";
            }
        }
        else
        {
            personajesLabel.Text = "No existen personajes";
        }
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        if(Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            using (var client = new HttpClient())
            {
                string url = $"https://rickandmortyapi.com/api/character/1,183";

                var respuesta = await client.GetAsync(url);

                if (respuesta.IsSuccessStatusCode)

                {
                    var json = await respuesta.Content.ReadAsStringAsync();
                    var personajes = JsonConvert.DeserializeObject<List<Root>>(json);

                    displayPerInformation(personajes);

                }             

            }
        }
    }
}