using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace pokemon
{
    public sealed partial class Batalla : UserControl
    {
        Combate combate;
        String pokemon1;
        String pokemon2;
        Dragonite dragonite1=new Dragonite();
        gardevoir gardevoir1=new gardevoir();
        jigglypuff jigglypuff1=new jigglypuff();
        zapdos zapdos1=new zapdos();

        Dragonite dragonite2 = new Dragonite();
        gardevoir gardevoir2 = new gardevoir();
        jigglypuff jigglypuff2 = new jigglypuff();
        zapdos zapdos2 = new zapdos();

        public Batalla(Combate combatee,String pokemonn1,String pokemonn2)
        {
            this.InitializeComponent();
            combate = combatee;
            pokemon1 = pokemonn1;
            pokemon2 = pokemonn2;
            abrirControlIzq();
            abrirControlDer();
        }
        private UserControl activeWindow = null;
        private UserControl activeWindow2 = null;
        public void OpenUserControl(UserControl cont)
        {
            if (activeWindow != null)
            {
                ventanaIzq.Children.Clear();
            }
            activeWindow = cont;
            ventanaIzq.Children.Add(cont);
        }
        public void OpenUserControl2(UserControl cont)
        {
            if (activeWindow2 != null)
            {
                VentanaDer.Children.Clear();
            }
            activeWindow = cont;
            VentanaDer.Children.Add(cont);
        }



        public void abrirControlIzq()
        {
            if (pokemon1 == "Dragonite")
            {
                OpenUserControl(dragonite1);
            }
            else if(pokemon1 == "Gardevoir"){
                OpenUserControl(gardevoir1);
            }
            else if (pokemon1 == "Zapdos")
            {
                OpenUserControl(zapdos1);
            }
            else if (pokemon1 == "Jigglypuff")
            {
                OpenUserControl(jigglypuff1);
            }

        }
        public void abrirControlDer()
        {
            if (pokemon2 == "Dragonite")
            {
                OpenUserControl2(dragonite2);
            }
            else if (pokemon2 == "Gardevoir")
            {
                OpenUserControl2(gardevoir2);
            }
            else if (pokemon2 == "Zapdos")
            {
                OpenUserControl2(zapdos2);
            }
            else if (pokemon2 == "Jigglypuff")
            {
                OpenUserControl2(jigglypuff2);
            }
        }
        public void hacerataque()
        {
            
        }

        private void Curar1_Click(object sender, RoutedEventArgs e)
        {
            bloquearJugador1();
            gardevoir1.subiendoVida();
            zapdos1.subiendoVida();
            dragonite1.subiendoVida();
            jigglypuff1.subiendoVida();
            desbloquearJugador2();
        }

        private  async void atacar1_Click(object sender, RoutedEventArgs e)
        {
            bloquearJugador1();
            gardevoir1.hacerataque();
            zapdos1.hacerataque();
            jigglypuff1.hacerataque();
            dragonite1.hacerataque();
            switch(pokemon1){
                case "Dragonite":
                    gardevoir2.bajandoVida(dragonite1.danio);
                    zapdos2.bajandoVida(dragonite1.danio);
                    jigglypuff2.bajandoVida(dragonite1.danio);
                    dragonite2.bajandoVida(dragonite1.danio);
                    break;
                case "Gardevoir":
                    gardevoir2.bajandoVida(gardevoir1.danio); 
                    zapdos2.bajandoVida(gardevoir1.danio);
                    jigglypuff2.bajandoVida(gardevoir1.danio);
                    dragonite2.bajandoVida(gardevoir1.danio);
                    break;
                case "Jigglypuff":
                    gardevoir2.bajandoVida(jigglypuff1.danio);
                    zapdos2.bajandoVida(jigglypuff1.danio);
                    jigglypuff2.bajandoVida(jigglypuff1.danio);
                    dragonite2.bajandoVida(jigglypuff1.danio);
                    break;
                case "Zapdos":
                    gardevoir2.bajandoVida(zapdos1.danio);
                    zapdos2.bajandoVida(zapdos1.danio);
                    jigglypuff2.bajandoVida(zapdos1.danio);
                    dragonite2.bajandoVida(zapdos1.danio);

                    break;


            }
            if (gardevoir2.vidaTotal <= 0 || zapdos2.vidaTotal <= 0 || jigglypuff2.vidaTotal <= 0 || dragonite2.vidaTotal <= 0)
            {

                await Task.Delay(5000);
                combate.abrirVictoria2(jugador1.Text, pokemon1, pokemon2,2);
            }
            else
            {
                desbloquearJugador2();
            }
            
        }
        public void bloquearJugador1()
        {
            rectangulo1.Visibility = Visibility.Visible;
            turnoJugador1.Visibility = Visibility.Visible;
        }
        public async void desbloquearJugador1()
        {
            await Task.Delay(4000);
            rectangulo1.Visibility=Visibility.Collapsed;
            turnoJugador1.Visibility=Visibility.Collapsed;
        }
        public void bloquearJugador2()
        {
            rectangulo2.Visibility=Visibility.Visible;
            turnoJugador2.Visibility = Visibility.Visible;
        }
        public async void desbloquearJugador2()
        {
            await Task.Delay(4000);
            rectangulo2.Visibility = Visibility.Collapsed;
            turnoJugador2.Visibility = Visibility.Collapsed;
        }

        private async void atacar2_Click(object sender, RoutedEventArgs e)
        {
            bloquearJugador2();
            gardevoir2.hacerataque();
            zapdos2.hacerataque();
            jigglypuff2.hacerataque();
            dragonite2.hacerataque();
            switch (pokemon2)
            {
                case "Dragonite":
                    gardevoir1.bajandoVida(dragonite2.danio);
                    zapdos1.bajandoVida(dragonite2.danio);
                    jigglypuff1.bajandoVida(dragonite2.danio);
                    dragonite1.bajandoVida(dragonite2.danio);
                    break;
                case "Gardevoir":
                    gardevoir1.bajandoVida(gardevoir2.danio);
                    zapdos1.bajandoVida(gardevoir2.danio);
                    jigglypuff1.bajandoVida(gardevoir2.danio);
                    dragonite1.bajandoVida(gardevoir2.danio);
                    break;
                case "Jigglypuff":
                    gardevoir1.bajandoVida(jigglypuff2.danio);
                    zapdos1.bajandoVida(jigglypuff2.danio);
                    jigglypuff1.bajandoVida(jigglypuff2.danio);
                    dragonite1.bajandoVida(jigglypuff2.danio);
                    break;
                case "Zapdos":
                    gardevoir1.bajandoVida(zapdos2.danio);
                    zapdos1.bajandoVida(zapdos2.danio);
                    jigglypuff1.bajandoVida(zapdos2.danio);
                    dragonite1.bajandoVida(zapdos2.danio);

                    break;


            }
            if (gardevoir1.vidaTotal <= 0 || zapdos1.vidaTotal <= 0 || jigglypuff1.vidaTotal <= 0 || dragonite1.vidaTotal <= 0)
            {

                await Task.Delay(5000);
                combate.abrirVictoria2(jugador1.Text, pokemon1, pokemon2,2);
            }
            else
            {
                desbloquearJugador1();
            }
            
        }

        private void curar2_Click(object sender, RoutedEventArgs e)
        {
            bloquearJugador2();
            gardevoir2.subiendoVida();
            dragonite2.subiendoVida();
            zapdos2.subiendoVida();
            jigglypuff2.subiendoVida();
            desbloquearJugador1();
        }

        private void subirAtaque1_Click(object sender, RoutedEventArgs e)
        {
            bloquearJugador1();
            gardevoir1.incrementarDanio();
            zapdos1.incrementarDanio();
            jigglypuff1.incrementarDanio();
            dragonite1.incrementarDanio();
            desbloquearJugador2();
        }

        private void subirAtaque2_Click(object sender, RoutedEventArgs e)
        {
            bloquearJugador2();
            gardevoir2.incrementarDanio();
            zapdos2.incrementarDanio();
            jigglypuff2.incrementarDanio();
            dragonite2.incrementarDanio();
            desbloquearJugador1();
        }

        private void atras_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirElegirPokemon2();
        }



        private void rendirse2_Click(object sender, RoutedEventArgs e)
        {
            combate.abrirVictoria2(jugador1.Text, pokemon1, pokemon1, 2);
        }

        private void rendirse1_Click(object sender, RoutedEventArgs e)
        {
            combate.abrirVictoria2(jugador2.Text, pokemon1, pokemon1, 2);
        }
    }
}
