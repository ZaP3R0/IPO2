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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace pokemon
{
    public sealed partial class zapdos : UserControl
    {
        DispatcherTimer dtReloj;
        public double vidaTotal = 100.0;
        public double danio = 15.0;
        public double danioRival;
        Storyboard sbOjoDer;
        Storyboard sbVolar;
        Storyboard sbOjoIzq;
        public zapdos()
        {
            this.InitializeComponent();
            BarraSalud.Value = vidaTotal;
            BarraEscudo.Value = danio;
            animacion();
           
        }
        private async void animacion()
        {
            sbOjoDer = (Storyboard)this.ePupilaDer.Resources["sbColorOjoDerKey"];
            sbOjoIzq = (Storyboard)this.ePupilaIzq.Resources["sbColorOjoIzqKey"];
            sbVolar = (Storyboard)this.Resources["Vuelo"];
            sbVolar.Begin();
            sbOjoDer.Begin();
            sbOjoIzq.Begin();
        }
        public void incrementarDanio()
        {
            if (danio < 100)
            {
                Random r = new Random();
                int num = r.Next(1, 30);
                danio += num;
            }
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += IncrementarBarraDanio;
            dtReloj.Start();
        }
        void IncrementarBarraDanio(object sender, object e)
        {
            this.BarraEscudo.Value += 1;
            if (BarraEscudo.Value >= danio || BarraEscudo.Value >= 100)
            {
                dtReloj.Stop();

            }
        }
        public void bajandoVida(double daniori)
        {
            danioRival = daniori;
            vidaTotal -= danioRival;
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += DecrementarBarra;
            dtReloj.Start();
        }
        void DecrementarBarra(object sender, object e)
        {
            try
            {
                this.BarraSalud.Value -= 1;


                if (BarraSalud.Value <= 0.0 || BarraSalud.Value <= vidaTotal)
                {
                    dtReloj.Stop();
                    if (BarraSalud.Value <= 0)
                    {
                        Storyboard sbMorir = (Storyboard)this.Resources["Morir"];
                        Storyboard sbFin = (Storyboard)this.Resources["Fin_Partida"];
                        sbMorir.Begin();
                        sbFin.Begin();
                    }

                }
            }
            catch
            {

            }
             
        
    }
        public void subiendoVida()
        {
            vidaTotal += 50;
            if (vidaTotal >= 100.0)
            {
                vidaTotal = 100.0;
            }
                Storyboard sbOjoDer = (Storyboard)this.ePupilaDer.Resources["sbColorOjoDerKey"];
            Storyboard sbOjoIzq = (Storyboard)this.ePupilaIzq.Resources["sbColorOjoIzqKey"];
            sbOjoDer.Begin();
            sbOjoIzq.Begin();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += IncrementarBarra;
            dtReloj.Start();
        }

        void IncrementarBarra(object sender, object e)
        {
            this.BarraSalud.Value += 1;
            if (BarraSalud.Value >= vidaTotal || BarraSalud.Value >= 100)
            {
                dtReloj.Stop();
                sbColorOjoDer.Stop();
                sbColorOjoIzq.Stop();
            }
        }

        public void hacerataque()
        {
        }



        private void Image_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += IncrementarBarraa;
            dtReloj.Start();
            imgPocion.Visibility = Visibility.Collapsed;

        }
        void IncrementarBarraa(object sender, object e)
        {
            Storyboard sbRevivir = (Storyboard)this.Resources["Revivir"];
            Storyboard sbFin = (Storyboard)this.Resources["Fin_Partida"];

            this.BarraSalud.Value += 2.5;

            if (BarraSalud.Value >= 100.0)
            {
                dtReloj.Stop();
            }

            if (BarraSalud.Value >= 100.0 && BarraEscudo.Value <= 0.0)
            {
                sbRevivir.Begin();
                sbFin.Stop();
            }
        }

        private void imgEspadas_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += DecrementarBarraa;
            dtReloj.Start();
            imgEspadas.Visibility = Visibility.Collapsed;
        }

        void DecrementarBarraa(object sender, object e)
        {
            Storyboard sbMorir = (Storyboard)this.Resources["Morir"];
            Storyboard sbFin = (Storyboard)this.Resources["Fin_Partida"];

            this.BarraEscudo.Value -= 3;
            this.BarraSalud.Value -= 1.5;


            if (BarraEscudo.Value <= 0.0 && BarraSalud.Value <= 0.0)
            {
                dtReloj.Stop();
                sbMorir.Begin();
                sbFin.Begin();
            }
        }
        }
}
