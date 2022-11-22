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
    public sealed partial class ElegirPokemon : UserControl
    {
        Boolean eleccion1 = false;
        Boolean eleccion2 = false;
        Combate combate;
        public ElegirPokemon(Combate combatee)
        {
            this.InitializeComponent();
            combate = combatee;
        }

        private void NumeroJugadores_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void dragonite2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon2.Text = "Dragonite";
            aceptar2.Visibility = Visibility.Visible;
        }

        private void gardevoir2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon2.Text = "Gardevoir";
            aceptar2.Visibility = Visibility.Visible;
        }

        private void jigglypuff2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon2.Text = "Jigglypuff";
            aceptar2.Visibility = Visibility.Visible;
        }

        private void zapdos2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokemon2.Text = "Zapdos";
            aceptar2.Visibility = Visibility.Visible;
        }

        private void aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (pokemon1.Text != "Seleccione un pokemon")
            {
                eleccion1 = true;
                if (eleccion1.Equals(true) && eleccion2.Equals(true))
                {
                    combate.abrirBatalla(combate, pokemon1.Text, pokemon2.Text);
                }
                dragonite1.Visibility = Visibility.Collapsed;
                gardevoir1.Visibility = Visibility.Collapsed;
                jigglypuff1.Visibility = Visibility.Collapsed;
                zapdos1.Visibility = Visibility.Collapsed;
                pokeball1.Visibility = Visibility.Visible;
                aceptar.Visibility = Visibility.Collapsed;
                Cancelar.Visibility = Visibility.Visible;
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            eleccion1 = false;
            dragonite1.Visibility = Visibility.Visible;
            gardevoir1.Visibility = Visibility.Visible;
            jigglypuff1.Visibility = Visibility.Visible;
            zapdos1.Visibility = Visibility.Visible;
            pokeball1.Visibility = Visibility.Collapsed;
            aceptar.Visibility = Visibility.Visible;
            Cancelar.Visibility = Visibility.Collapsed;
        }

        private void pokeball1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            eleccion1 = false;
            dragonite1.Visibility = Visibility.Visible;
            gardevoir1.Visibility = Visibility.Visible;
            jigglypuff1.Visibility = Visibility.Visible;
            zapdos1.Visibility = Visibility.Visible;
            pokeball1.Visibility = Visibility.Collapsed;
            aceptar.Visibility = Visibility.Visible;
            Cancelar.Visibility = Visibility.Collapsed;
        }

        private void aceptar2_Click(object sender, RoutedEventArgs e)
        {
            if (pokemon2.Text != "Seleccione un pokemon")
            {


                eleccion2 = true;
                if (eleccion1.Equals(true) && eleccion2.Equals(true))
                {
                    combate.abrirBatalla(combate, pokemon1.Text, pokemon2.Text);
                }
                dragonite2.Visibility = Visibility.Collapsed;
                gardevoir2.Visibility = Visibility.Collapsed;
                jigglypuff2.Visibility = Visibility.Collapsed;
                zapdos2.Visibility = Visibility.Collapsed;
                pokeball2.Visibility = Visibility.Visible;
                aceptar2.Visibility = Visibility.Collapsed;
                cancelar2.Visibility = Visibility.Visible;
            }
        }

        private void cancelar2_Click(object sender, RoutedEventArgs e)
        {
            eleccion2 = false;
            dragonite2.Visibility = Visibility.Visible;
            gardevoir2.Visibility = Visibility.Visible;
            jigglypuff2.Visibility = Visibility.Visible;
            zapdos2.Visibility = Visibility.Visible;
            pokeball2.Visibility = Visibility.Collapsed;
            aceptar2.Visibility = Visibility.Visible;
            cancelar2.Visibility = Visibility.Collapsed;
        }

        private void pokeball2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            eleccion2 = false;
            dragonite2.Visibility = Visibility.Visible;
            gardevoir2.Visibility = Visibility.Visible;
            jigglypuff2.Visibility = Visibility.Visible;
            zapdos2.Visibility = Visibility.Visible;
            pokeball2.Visibility = Visibility.Collapsed;
            aceptar2.Visibility = Visibility.Visible;
            cancelar2.Visibility = Visibility.Collapsed;
        }

        private void atras_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirNumeroJugadores();
        }
    }
}
