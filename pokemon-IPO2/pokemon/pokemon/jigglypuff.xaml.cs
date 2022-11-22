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
    public sealed partial class jigglypuff : UserControl
    {
        public double vidaTotal = 100.0;
        public double danio = 15.0;
        public double danioRival;
        DispatcherTimer dtReloj;

        public jigglypuff()
        {
            this.InitializeComponent();
            saludar();
        }

        public async void hacerataque()
        {
            Storyboard sbCantar = (Storyboard)this.Resources["Cantar"];
            sbCantar.Begin();
            await Task.Delay(3000);
            sbCantar.Stop();
        }



        public void saludar()
        {
            Storyboard sbSaludar = (Storyboard)this.Resources["Saludar"];
            sbSaludar.Begin();
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
            this.pbDanio.Value += 1;
            if (pbDanio.Value >= danio || pbDanio.Value >= 100)
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
            dtReloj.Tick += DecrementarBarraa;
            dtReloj.Start();
        }

        void DecrementarBarraa(object sender, object e)
        {
            this.barrael_progre.Value -= 1;
            if (barrael_progre.Value <= vidaTotal || barrael_progre.Value <= 0)
            {
                dtReloj.Stop();
                if (barrael_progre.Value <= 0)
                {
                    Storyboard sbmuerte = (Storyboard)this.Resources["muerte"];
                    sbmuerte.Begin();

                }

            }
        }
        public void subiendoVida()
        {
            vidaTotal += 50;
            if (vidaTotal >= 100.0)
            {
                vidaTotal = 100.0;
            }
                saludar();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += IncrementaBarra;
            dtReloj.Start();
        }

        void IncrementaBarra(object sender, object e)
        {
            this.barrael_progre.Value += 1;
            if (barrael_progre.Value >= vidaTotal || barrael_progre.Value >= 100)
            {
                dtReloj.Stop();
            }
        }










        private void Cantar(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbCantar = (Storyboard)this.Resources["Cantar"];
            sbCantar.Begin();
        }

        private void saludar(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbSaludar = (Storyboard)this.Resources["Saludar"];
            sbSaludar.Begin();
        }
        void DecrementarBarra(object sender, object e)
        {
            barrael_progre.Value -= 0.5;
            if (barrael_progre.Value == 0)
            {
                dtReloj.Stop();
                Storyboard sbmuerte = (Storyboard)this.Resources["muerte"];
                sbmuerte.Begin();
            }

        }
        void IncrementarBarra(object sender, object e)
        {
            barrael_progre.Value += 0.5;
            if (barrael_progre.Value == 100)
            {
                dtReloj.Stop();
            }
        }

        private void Cuerpo_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(15);
            dtReloj.Tick += DecrementarBarra;
            dtReloj.Start();

        }

        private void impocima_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            dtReloj = new DispatcherTimer();
            if (barrael_progre.Value == 0)
            {
                Storyboard sbRecuperar = (Storyboard)this.Resources["Recuperar"];
                sbRecuperar.Begin();
            }


            dtReloj.Interval = TimeSpan.FromMilliseconds(15);
            dtReloj.Tick += IncrementarBarra;
            dtReloj.Start();
        }

        private void morir(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbmuerte = (Storyboard)this.Resources["muerte"];
            sbmuerte.Begin();
        }

        private void recuperar(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbRecuperar = (Storyboard)this.Resources["Recuperar"];
            sbRecuperar.Begin();
        }
    }
}
