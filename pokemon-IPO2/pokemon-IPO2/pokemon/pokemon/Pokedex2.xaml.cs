using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
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
    public sealed partial class Pokedex2 : UserControl
    {
        Pokedex pokedex;
        public Pokedex2(Pokedex pokedeex)
        {
            this.InitializeComponent();
            pokedex = pokedeex;
        }

        private UserControl activeWindow = null;

        public void OpenUserControl(UserControl cont)
        {
            if (activeWindow != null)
            {
                Pokedex.Children.Clear();
            }
            activeWindow = cont;
            Pokedex.Children.Add(cont);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pokedex.abrirGardevoir();
        }

        private void DragoniteClick(object sender, RoutedEventArgs e)
        {
            pokedex.abrirDragonite();
        }

        private void JigglyClick(object sender, RoutedEventArgs e)
        {
            pokedex.abrirJigglypuff();
        }

        private void ZapdosClick(object sender, RoutedEventArgs e)
        {
            pokedex.abrirZapdos();
        }

        private void CharizardClick(object sender, RoutedEventArgs e)
        {
            pokedex.abrirCharizard();
        }

        private void ClickOnix(object sender, RoutedEventArgs e)
        {
            pokedex.abrirOnix();
        }
    }
}
