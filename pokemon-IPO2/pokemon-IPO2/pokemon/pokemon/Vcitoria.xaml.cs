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
    public sealed partial class Vcitoria : UserControl
    {
        Combate combate;
        String ganador,pokemon1,pokemon2;
        Int32 num;



        public Vcitoria(Combate combatee, String ganadorr, String pokemonn1, String pokemonn2, Int32 numJ)
        {
            this.InitializeComponent();
            combate = combatee;
            ganador = ganadorr;
            pokemon1 = pokemonn1;
            pokemon2 = pokemonn2;
            num = numJ;
            Ganador.Text = "ENHORABUENA " + ganador + " HAS GANADO EL COMBATE";
        }

        private void IrBatalla_Click(object sender, RoutedEventArgs e)
        {
            if (num == 2)
            {
                combate.abrirBatalla(combate, pokemon1, pokemon2);
            }
            else
            {
                combate.abrirBatalla1P(pokemon1, pokemon2);
            }
            
        }

        private void IrElegir_Click(object sender, RoutedEventArgs e)
        {
            if (num == 2)
            {
                combate.abrirElegirPokemon2();
            }
            else
            {
                combate.abrirElegirPokemon1();
            }
            
            
        }

        private void IrInicio_Click(object sender, RoutedEventArgs e)
        {
            combate.abrirNumeroJugadores();
        }
    }
}
