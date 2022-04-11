using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Blank_Lember_TARgv20
{
    public partial class MainPage : ContentPage
    {
        Button go_to_game;
        public MainPage()
        {
            go_to_game = new Button
            {
                Text = "Mängima",
                BackgroundColor = Color.GreenYellow
            };
            StackLayout st = new StackLayout
            {
                Children = { go_to_game }
            };
            st.BackgroundColor = Color.Aqua;
            Content = st;

            go_to_game.Clicked += Go_to_game_Clicked;

        }

        private async void Go_to_game_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Game_Page());
            await DisplayAlert("Pop up", "Soovi korral mängu alguses võib valida esimest mängijat, vajutades nuppule üleval pool", "OK");
        }
    }
}
