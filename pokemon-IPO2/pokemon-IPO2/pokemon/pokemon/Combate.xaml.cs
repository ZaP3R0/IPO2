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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace pokemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Combate : Page
    {
        public Combate()
        {
            this.InitializeComponent();
            OpenUserControl(new NumeroJugadores(this));
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
        public void abrirNumeroJugadores()
        {
            OpenUserControl(new NumeroJugadores(this));
        }
        public void abrirElegirPokemon2()
        {
            OpenUserControl(new ElegirPokemon(this));
        }
        public void abrirBatalla(Combate combate, String pokemon1,String pokemon2)
        {
            OpenUserControl(new Batalla(combate, pokemon1, pokemon2));
        }
        public void abrirBatalla1P(String pokemon1, String pokemon2)
        {
            OpenUserControl(new Batalla1P(this, pokemon1, pokemon2));
        }
        public void abrirElegirPokemon1()
        {
            OpenUserControl(new ElegirP2Jugadores(this));
        }
        public void abrirVictoria2(String ganador,String pokemon1,String pokemon2,Int32 num)
        {
            OpenUserControl(new Vcitoria(this,ganador,pokemon1,pokemon2,num));
        }
        

        

    }
}
