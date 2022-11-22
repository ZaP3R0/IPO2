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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace pokemon
{
    public sealed partial class NumeroJugadores : UserControl
    {
        DispatcherTimer dtReloj;
        Storyboard vida;
        Combate combate;
        public NumeroJugadores(Combate combatee)
        {
            combate = combatee;
            this.InitializeComponent();
        }

        private void RdosJugadores_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirElegirPokemon2();
        }

        private void Image_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirElegirPokemon2();
        }

        private void txtDosjuga_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirElegirPokemon2();
        }

        private void Image_PointerReleased_1(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirElegirPokemon1();
        }

        private void Rectangle_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirElegirPokemon1();
        }

        private void TextBlock_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            combate.abrirElegirPokemon1();
        }
    }
}
