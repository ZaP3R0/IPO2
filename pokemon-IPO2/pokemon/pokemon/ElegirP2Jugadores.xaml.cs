using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ElegirP2Jugadores : UserControl
    {
        Combate combate;
        public ElegirP2Jugadores(Combate combatee)
        {
            this.InitializeComponent();
            combate = combatee;
            eleccionAleatoria();
        }

        private void dragonite1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon1.Text = "Dragonite";
            aceptar.Visibility = Visibility.Visible;
        }

        private void gardevoir1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon1.Text = "Gardevoir";
            aceptar.Visibility = Visibility.Visible;
        }

        private void jigglypuff1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon1.Text = "Jigglypuff";
            aceptar.Visibility = Visibility.Visible;
        }

        private void zapdos1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon1.Text = "Zapdos";
            aceptar.Visibility = Visibility.Visible;
        }
        private void aceptar_Click(object sender, RoutedEventArgs e)
        {
               combate.abrirBatalla1P(pokemon1.Text, pokemon2.Text);
            
        }
        public void eleccionAleatoria()
        {
            Random r = new Random();
            int num = r.Next(1, 5);
            switch (num)
            {
                case 1:
                    pokemon2.Text = "Dragonite";
                    break;
                case 2:
                    pokemon2.Text = "Gardevoir";
                    break;
                case 3:
                    pokemon2.Text = "Jigglypuff";
                    break;
                case 4:
                    pokemon2.Text = "Zapdos";
                    break;

            }
        }

        private void atras_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirNumeroJugadores();
        }
    }
}
