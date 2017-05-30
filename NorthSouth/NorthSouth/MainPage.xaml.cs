using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace NorthSouth
{
    public partial class MainPage : ContentPage
    {
        HttpClient client;

        public MainPage()
        {
            InitializeComponent();

            client = new HttpClient();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var uri = new Uri("http://north2south.herokuapp.com/checkpoints");
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    label.Text = content.ToString();
                }
            }
            catch(Exception ex)
            {
                label.Text = ex.Message.ToString();
            }
        }
    }
}
