using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blank_Lember_TARgv20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game_Page : ContentPage
    {
        Button btn_player, clean_btn;
        Frame fr;
        Grid gr;
        BoxView b;
        bool result=true;
        int player;
        int[,] values = new int[3, 3];
        public Game_Page()
        {
            btn_player = new Button
            {
                Text = "Vali mängija"
            };
            clean_btn = new Button
            {
                Text = "Uus mäng",
                BackgroundColor=Color.LightBlue
            };
            btn_player.Clicked += Btn_player_Clicked;
            clean_btn.Clicked += Clean_btn_Clicked;

            gr = new Grid();
            for (int i = 0; i < 3; i++)
            {
                gr.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            };
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    b = new BoxView { Color = Color.White };
                    gr.Children.Add(b, c, r);
            
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }
            }

            fr = new Frame
            {
                Content = gr,
                BorderColor = Color.FromRgb(20, 120, 255),
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { btn_player, clean_btn, fr }
            };
            Content = st;

        }
        private async void Btn_player_Clicked(object sender, EventArgs e)
        {
            result = await DisplayAlert("Pop up", "Vali mängija", "Esimene - rohelised", "Teine - kollane");
            btn_player.IsEnabled = false;
        }
        int tapid;
        private async void Tap_Tapped(object sender, EventArgs e)
        {
            btn_player.IsEnabled = false;
            var b = (BoxView)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (result)
            {
                btn_player.Text = "Mängija 1";
                btn_player.BackgroundColor = Color.Green;
                b.Color = Color.Green;
                player = 1;
                result = false;
            }
            else
            {
                result = true;
                btn_player.Text = "Mängija 2";
                btn_player.BackgroundColor = Color.Yellow;
                b.Color = Color.Yellow;
                player = 2;
            }
            values[r, c] = player;
            CheckWinner();

        }
        async void CheckWinner()
        {
            if (values[0, 0] == 1 & values[0, 1] == 1 & values[0, 2] == 1 ||
                values[1, 0] == 1 & values[1, 1] == 1 & values[1, 2] == 1 ||
                values[2, 0] == 1 & values[2, 1] == 1 & values[2, 2] == 1 ||

                values[0, 0] == 1 & values[1, 0] == 1 & values[2, 0] == 1 ||
                values[0, 1] == 1 & values[1, 1] == 1 & values[2, 1] == 1 ||
                values[0, 2] == 1 & values[1, 2] == 1 & values[2, 2] == 1 ||

                values[0, 0] == 1 & values[1, 1] == 1 & values[2, 2] == 1 ||
                values[0, 2] == 1 & values[1, 1] == 1 & values[2, 0] == 1)
            {
                await DisplayAlert("Pop up", "Esimene mängija võitis! Palun valu uus mäng", "OK");
            }
            else if (values[0, 0] == 2 & values[0, 1] == 2 & values[0, 2] == 2 ||
                values[1, 0] == 2 & values[1, 1] == 2 & values[1, 2] == 2 ||
                values[2, 0] == 2 & values[2, 1] == 2 & values[2, 2] == 2 ||

                values[0, 0] == 2 & values[1, 0] == 2 & values[2, 0] == 2 ||
                values[0, 1] == 2 & values[1, 1] == 2 & values[2, 1] == 2 ||
                values[0, 2] == 2 & values[1, 2] == 2 & values[2, 2] == 2 ||

                values[0, 0] == 2 & values[1, 1] == 2 & values[2, 2] == 2 ||
                values[0, 2] == 2 & values[1, 1] == 2 & values[2, 0] == 2)
            {
                await DisplayAlert("Pop up", "Teine mängija võitis! Palun valu uus mäng", "OK");
            }
        }
        private async void Clean_btn_Clicked(object sender, EventArgs e)
        {
            result = await DisplayAlert("Pop up", "Kas oled kindel, et soovid lõppetada?", "Yah", "Ei");
            if (result)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}