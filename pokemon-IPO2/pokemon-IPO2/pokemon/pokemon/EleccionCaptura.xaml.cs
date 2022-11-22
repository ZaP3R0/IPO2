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
    public sealed partial class EleccionCaptura : UserControl
    {
        Captura captura;
        public EleccionCaptura(Captura capturaa)
        {
            this.InitializeComponent();
            captura = capturaa;
        }

        private void dragonite_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon_elegido.Text = "Dragonite";
            but_aceptar.Visibility = Visibility.Visible;
        }

        private void gardevoir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon_elegido.Text = "Gardevoir";
            but_aceptar.Visibility = Visibility.Visible;
        }

        private void jigglypuff_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon_elegido.Text = "Jigglypuff";
            but_aceptar.Visibility = Visibility.Visible;
        }

        private void zapdos_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon_elegido.Text = "Zapdos";
            but_aceptar.Visibility = Visibility.Visible;
        }

        private void aceptar_Click(object sender, RoutedEventArgs e)
        {
            captura.abrirCapturarPokemon(captura, pokemon_elegido.Text);
            dragonite.Visibility = Visibility.Collapsed;
            gardevoir.Visibility = Visibility.Collapsed;
            jigglypuff.Visibility = Visibility.Collapsed;
            zapdos.Visibility = Visibility.Collapsed;
            pokeball.Visibility = Visibility.Collapsed;
            but_aceptar.Visibility = Visibility.Collapsed;
        }
    }
}
