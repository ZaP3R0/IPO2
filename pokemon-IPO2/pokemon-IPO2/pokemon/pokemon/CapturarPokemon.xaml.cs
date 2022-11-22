using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace pokemon
{
    public sealed partial class CapturarPokemon : UserControl
    {
        Captura captura;
        String pokemon;
        Boolean control = false;
        Dragonite dragonite = new Dragonite();
        gardevoir gardevoir = new gardevoir();
        jigglypuff jigglypuff = new jigglypuff();
        zapdos zapdos = new zapdos();
        DispatcherTimer dtPokeball;

        public CapturarPokemon(Captura capturaa, String pokemonn)
        {
            this.InitializeComponent();
            captura = capturaa;
            pokemon = pokemonn;
            abrirControl();
        }
        private UserControl activeWindow = null;
        public void OpenUserControl(UserControl cont)
        {
            if (activeWindow != null)
            {
                ventana.Children.Clear();
            }
            activeWindow = cont;
            ventana.Children.Add(cont);
        }
        public void abrirControl()
        {
            if (pokemon == "Dragonite")
            {
                OpenUserControl(dragonite);
            }
            else if (pokemon == "Gardevoir")
            {
                OpenUserControl(gardevoir);
            }
            else if (pokemon == "Zapdos")
            {
                OpenUserControl(zapdos);
            }
            else if (pokemon == "Jigglypuff")
            {
                OpenUserControl(jigglypuff);
            }

        }

        private void atacar1_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int num = r.Next(10, 30);
            if (pokemon == "Dragonite")
            {
                dragonite.bajandoVida(num);
            }
            else if (pokemon == "Gardevoir")
            {
                gardevoir.bajandoVida(num);
            }
            else if (pokemon == "Zapdos")
            {
                zapdos.bajandoVida(num);
            }
            else if (pokemon == "Jigglypuff")
            {
                jigglypuff.bajandoVida(num);
            }
        }

        private void Curar1_Click(object sender, RoutedEventArgs e)
        {
            dtPokeball = new DispatcherTimer();
            dtPokeball.Tick += Pokeball;
            dtPokeball.Start();
        }

        private void Pokeball(object sender, object e)
        {
            Storyboard sbCaptura1 = (Storyboard)this.Resources["Captura1"];
            Storyboard sbCaptura2 = (Storyboard)this.Resources["Captura2"];
            Storyboard sbCaptura3 = (Storyboard)this.Resources["Captura3"];
            Storyboard sbCaptura4 = (Storyboard)this.Resources["Captura4"];
            int aux = capturaAleatoria();
            if (aux == 1)
            {
                sbCaptura1.Begin();
            }
            else if (aux == 2)
            {
                sbCaptura2.Begin();
            }
            else if (aux == 3)
            {
                sbCaptura3.Begin();
            }
            else if (aux == 4)
            {
                sbCaptura4.Begin();
                control = true;
            }
            this.dtPokeball.Stop();

        }
        private int capturaAleatoria()
        {
            int num = 0;
            if (pokemon == "Jigglypuff")
            {
                num = conversorProbabilidadRojo();
            }
            else if (pokemon == "Gardevoir" || pokemon == "Dragonite")
            {
                num = conversorProbabilidadAmarillo();
            }
            else if (pokemon == "Zapdos")
            {
                num = conversorProbabilidadVerde();
            }
            return num;
        }
        private int conversorProbabilidadRojo()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;


            if (num == 1 || num == 2)
            {
                tipoCaptura = 2;
            }
            else if (num == 3 || num == 4 || num == 5)
            {
                tipoCaptura = 3;
            }
            else if (num == 6 || num == 7 || num == 8 || num == 9 || num == 10 || num == 11 || num == 12 || num == 13 || num == 14 || num == 15 || num == 16 || num == 17 || num == 18 || num == 19 || num == 20)
            {
                tipoCaptura = 4;
            }
            return tipoCaptura;
        }
        private int conversorProbabilidadAmarillo()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;

            if (num == 1 || num == 2)
            {
                tipoCaptura = 1;
            }
            else if (num == 3 || num == 4 || num == 5)
            {
                tipoCaptura = 2;
            }
            else if (num == 6 || num == 7 || num == 8 || num == 9)
            {
                tipoCaptura = 3;
            }
            else if (num == 10 || num == 11 || num == 12 || num == 13 || num == 14 || num == 15 || num == 16 || num == 17 || num == 18 || num == 19 || num == 20)
            {
                tipoCaptura = 4;
            }
            return tipoCaptura;
        }
        private int conversorProbabilidadVerde()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;

            if (num == 1 || num == 2 || num == 3)
            {
                tipoCaptura = 1;
            }
            else if (num == 4 || num == 5 || num == 6 || num == 7)
            {
                tipoCaptura = 2;
            }
            else if (num == 8 || num == 9 || num == 10 || num == 11 || num == 12 || num == 13)
            {
                tipoCaptura = 3;
            }
            else if (num == 14 || num == 15 || num == 16 || num == 17 || num == 18 || num == 19 || num == 20)
            {
                tipoCaptura = 4;
            }
            return tipoCaptura;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            captura.abrirEleccionCaptura(captura);
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (control)
            {
                new ToastContentBuilder()
                .AddArgument("action", "Capturas")
                .AddText("¡ENHORABUENA!")
                .AddText("¡Has capturado un " + pokemon + "!")
                .AddAppLogoOverride(new Uri("ms-appx:///Images/logo.jpg"), ToastGenericAppLogoCrop.Circle)
                .Show();
            }
            captura.abrirEleccionCaptura(captura);
        }

        private void Captura_Click(object sender, RoutedEventArgs e)
        {
            if (control)
            {
                new ToastContentBuilder()
                .AddArgument("action", "Capturas")
                .AddText("¡ENHORABUENA!")
                .AddText("¡Has capturado un " + pokemon + "!")
                .AddAppLogoOverride(new Uri("ms-appx:///Images/logo.jpg"), ToastGenericAppLogoCrop.Circle)
                .Show();
            }
            captura.abrirCapturarPokemon(captura, pokemon);
        }
    }
}
