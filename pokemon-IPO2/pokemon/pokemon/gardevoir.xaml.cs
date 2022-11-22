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
    public sealed partial class gardevoir : UserControl
    {
        public double vidaTotal = 100.0;
        public double danio = 15.0;
        public double danioRival;
        DispatcherTimer dtReloj;
        Storyboard vida;
        public gardevoir()
        {
            InitializeComponent();
            pbVida.Value=vidaTotal;
            pbDanio.Value=danio;
            
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
            if (pbDanio.Value >= danio||pbDanio.Value>=100)
            {
                dtReloj.Stop();
                
            }
        }

        public void bajandoVida(double daniori)
        {
            danioRival = daniori;
            vidaTotal -= danioRival;
            Storyboard sbdaniar = (Storyboard)this.Resources["danio"];
            sbdaniar.Begin();
            imPocion.Visibility = Visibility.Collapsed;
            daño.Visibility = Visibility.Collapsed;
            ataque1.Visibility = Visibility.Collapsed;
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += DecrementarBarra;
            dtReloj.Start();
        }
        public void subiendoVida()
        {
            vidaTotal += 50;
            if (vidaTotal >= 100.0)
            {
                vidaTotal = 100.0;
            }
                vida = (Storyboard)this.Resources["vida"];
            vida.Begin();
            imPocion.Visibility = Visibility.Collapsed;
            daño.Visibility = Visibility.Collapsed;
            ataque1.Visibility = Visibility.Collapsed;
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += IncrementarBarra;
            dtReloj.Start();
        }

        public void hacerataque()
        {
            Storyboard ataque = (Storyboard)this.Resources["ataque"];
            ataque.Begin();
        }
        public void subirVida(object sender, PointerRoutedEventArgs e)
        {
            vida = (Storyboard)this.Resources["vida"];
            vida.Begin();
            imPocion.Visibility = Visibility.Collapsed;
            daño.Visibility = Visibility.Collapsed;
            ataque1.Visibility = Visibility.Collapsed;
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += IncrementarBarra;
            dtReloj.Start();
        }
         void IncrementarBarra(object sender, object e)
        {
            this.pbVida.Value += 1;
            if (pbVida.Value >= vidaTotal||pbVida.Value>=100)
            {
                dtReloj.Stop();
                vida.Stop();
                imPocion.Visibility = Visibility.Visible;
                revivir.Visibility = Visibility.Collapsed;
                daño.Visibility = Visibility.Visible;
                ataque1.Visibility = Visibility.Visible;
            }
        }

        public void Image_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            Storyboard ataque = (Storyboard)this.Resources["ataque"];
            ataque.Begin();
        }

        public void daño_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            vidaTotal -= danioRival;
            Storyboard sbdaniar = (Storyboard)this.Resources["danio"];
            sbdaniar.Begin();
            imPocion.Visibility = Visibility.Collapsed;
            daño.Visibility = Visibility.Collapsed;
            ataque1.Visibility = Visibility.Collapsed;
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += DecrementarBarra;
            dtReloj.Start();
        }

        void DecrementarBarra(object sender, object e)
        {
            this.pbVida.Value -= 1;
            if (pbVida.Value <= vidaTotal || pbVida.Value<=0)
            {
                dtReloj.Stop();
                if (pbVida.Value <= 0)
                {
                    Storyboard sbmorir = (Storyboard)this.Resources["muerte"];
                    sbmorir.Begin();
                    imPocion.Visibility = Visibility.Collapsed;
                    revivir.Visibility = Visibility.Visible;
                }
                
            }
        }

        public void revivir_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbrevivir = (Storyboard)this.Resources["revivir"];
            sbrevivir.Begin();
            vida = (Storyboard)this.Resources["vida"];
            vida.Begin();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += IncrementoBarra;
            dtReloj.Start();
        }

        void IncrementoBarra(object sender, object e)
        {
            this.pbVida.Value += 2;
            if (pbVida.Value >= 50.0)
            {
                dtReloj.Stop();
                vida.Stop();
                imPocion.Visibility = Visibility.Visible;
                revivir.Visibility = Visibility.Collapsed;
                daño.Visibility = Visibility.Visible;
                ataque1.Visibility = Visibility.Visible;
            }
        }

        public void canvas_MouseUp(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbgirar = (Storyboard)this.Resources["girar"];
            sbgirar.Begin();
        }
    }
}
