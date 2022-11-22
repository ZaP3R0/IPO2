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
    public sealed partial class Dragonite : UserControl
    {
        DispatcherTimer dtCuracion;
        DispatcherTimer dtPokeball;

        public double vidaTotal = 100.0;
        public double danio = 15.0;
        public double danioRival;
        DispatcherTimer dtReloj;
        double control = 0;
        double controlE = 30;
        double controlC = 30;
        public Dragonite()
        {
            this.InitializeComponent();
            pb_escudo.Value = vidaTotal;
            pb_escudo.Value = danio;
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
            this.pb_escudo.Value += 1;
            if (pb_escudo.Value >= danio || pb_escudo.Value >= 100)
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
            this.pb_vida.Value -= 1;
            if (pb_vida.Value <= vidaTotal || pb_vida.Value <= 0)
            {
                dtReloj.Stop();
                if (pb_vida.Value <= 0)
                {
                    this.im_ojoDer.Visibility = Visibility.Visible;
                    this.im_ojoIzq.Visibility = Visibility.Visible;
                    this.OjoDerecho.Visibility = Visibility.Collapsed;
                    this.OjoIzquierdo.Visibility = Visibility.Collapsed;
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
                dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(25);
            dtReloj.Tick += IncrementarBarra;
            dtReloj.Start();
        }
        void IncrementarBarra(object sender, object e)
        {
            this.pb_vida.Value += 1;
            if (pb_vida.Value >= vidaTotal || pb_vida.Value >= 100)
            {
                dtReloj.Stop();

            }
        }
        public void hacerataque()
        {
            Storyboard sbLuchar = (Storyboard)this.Resources["Mordisco"];
            sbLuchar.Begin();
        }



























        private void usarPocion(object sender, PointerRoutedEventArgs e)
        {
            dtCuracion = new DispatcherTimer();
            dtCuracion.Interval = TimeSpan.FromMilliseconds(50);
            dtCuracion.Tick += subirVida;
            dtCuracion.Start();
            this.im_pocion.Opacity = 0.5;
        }
        private void subirVida(object sender, object e)
        {
            this.pb_vida.Value += 0.5;
            control += 0.5;
            colorVida();

            if (pb_vida.Value >= 20)
            {
                this.im_ojoDer.Visibility = Visibility.Collapsed;
                this.im_ojoIzq.Visibility = Visibility.Collapsed;
                this.OjoDerecho.Visibility = Visibility.Visible;
                this.OjoIzquierdo.Visibility = Visibility.Visible;
            }

            if (control == 20 || pb_vida.Value >= 100)
            {
                this.dtCuracion.Stop();
                this.im_pocion.Opacity = 1;
                control = 0;
                this.im_lucha.Opacity = 1;
                if (pb_vida.Value >= 100)
                {
                    this.dtCuracion.Stop();
                    this.im_pocion.Opacity = 0.0;
                    this.im_superpocion.Opacity = 0.0;
                }
            }
        }
        private void usarSuperPocion(object sender, PointerRoutedEventArgs e)
        {
            dtCuracion = new DispatcherTimer();
            dtCuracion.Interval = TimeSpan.FromMilliseconds(50);
            dtCuracion.Tick += subirVida2;
            dtCuracion.Start();
            this.im_superpocion.Opacity = 0.5;
        }
        private void subirVida2(object sender, object e)
        {
            this.pb_vida.Value += 0.5;
            control += 0.5;
            colorVida();

            if (pb_vida.Value >= 20)
            {
                this.im_ojoDer.Visibility = Visibility.Collapsed;
                this.im_ojoIzq.Visibility = Visibility.Collapsed;
                this.OjoDerecho.Visibility = Visibility.Visible;
                this.OjoIzquierdo.Visibility = Visibility.Visible;
            }

            if (control == 50 || pb_vida.Value >= 100)
            {
                this.dtCuracion.Stop();
                this.im_superpocion.Opacity = 1;
                control = 0;
                this.im_lucha.Opacity = 1;
                if (pb_vida.Value >= 100)
                {
                    this.dtCuracion.Stop();
                    this.im_superpocion.Opacity = 0.0;
                    this.im_pocion.Opacity = 0.0;
                }
            }
        }
        private void colorVida()
        {
            if (pb_vida.Value <= 20)
            {
                pb_vida.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else if (pb_vida.Value <= 50)
            {
                pb_vida.Foreground = new SolidColorBrush(Windows.UI.Colors.Yellow);
            }
            else
                pb_vida.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private void usarPokeball(object sender, PointerRoutedEventArgs er)
        {
            dtPokeball = new DispatcherTimer();
            dtPokeball.Tick += Pokeball;
            dtPokeball.Start();
            this.im_pokeball.Opacity = 0.5;
        }

        private void Pokeball(object sender, object e)
        {
            Storyboard sbCaptura1 = (Storyboard)this.Resources["Captura_tipo1"];
            Storyboard sbCaptura2 = (Storyboard)this.Resources["Captura_tipo2"];
            Storyboard sbCaptura3 = (Storyboard)this.Resources["Captura_tipo3"];
            Storyboard sbCaptura4 = (Storyboard)this.Resources["Captura_tipo4"];
            Storyboard sbCaptura5 = (Storyboard)this.Resources["Captura_tipo5"];
            int aux = capturaAleatoria();
            if (aux == 1)
            {
                sbCaptura1.Begin();
            }
            else if (aux == 2)
            {
                sbCaptura2.Begin();
            }
            else if (aux == 3)
            {
                sbCaptura3.Begin();
            }
            else if (aux == 4)
            {
                sbCaptura4.Begin();
            }
            else if (aux == 5)
            {
                sbCaptura5.Begin();
            }
            this.dtPokeball.Stop();
            this.im_pokeball.Opacity = 0.0;
        }
        private int capturaAleatoria()
        {
            int num = 0;
            if (pb_vida.Value <= 20)
            {
                num = conversorProbabilidadRojo();
            }
            else if (pb_vida.Value <= 50)
            {
                num = conversorProbabilidadAmarillo();
            }
            else
            {
                num = conversorProbabilidadVerde();
            }
            return num;
        }
        private int conversorProbabilidadRojo()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;


            if (num == 1 || num == 2)
            {
                tipoCaptura = 2;
            }
            else if (num == 3 || num == 4 || num == 5)
            {
                tipoCaptura = 3;
            }
            else if (num == 6 || num == 7 || num == 8 || num == 9 || num == 10 || num == 11 || num == 12 || num == 13 || num == 14 || num == 15 || num == 16 || num == 17 || num == 18)
            {
                tipoCaptura = 4;
            }
            else if (num == 19 || num == 20)
            {
                tipoCaptura = 5;
            }
            return tipoCaptura;
        }
        private int conversorProbabilidadAmarillo()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;

            if (num == 1 || num == 2)
            {
                tipoCaptura = 1;
            }
            else if (num == 3 || num == 4 || num == 5)
            {
                tipoCaptura = 2;
            }
            else if (num == 6 || num == 7 || num == 8 || num == 9)
            {
                tipoCaptura = 3;
            }
            else if (num == 10 || num == 11 || num == 12 || num == 13 || num == 14 || num == 15 || num == 16 || num == 17 || num == 18 || num == 19)
            {
                tipoCaptura = 4;
            }
            else if (num == 20)
            {
                tipoCaptura = 5;
            }
            return tipoCaptura;
        }
        private int conversorProbabilidadVerde()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;

            if (num == 1 || num == 2 || num == 3)
            {
                tipoCaptura = 1;
            }
            else if (num == 4 || num == 5 || num == 6 || num == 7)
            {
                tipoCaptura = 2;
            }
            else if (num == 8 || num == 9 || num == 10 || num == 11 || num == 12 || num == 13)
            {
                tipoCaptura = 3;
            }
            else if (num == 14 || num == 15 || num == 16 || num == 17 || num == 18 || num == 19 || num == 20)
            {
                tipoCaptura = 4;
            }
            return tipoCaptura;
        }
        private void usarPelear(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbLuchar = (Storyboard)this.Resources["Mordisco"];
            sbLuchar.Begin();
            dtCuracion = new DispatcherTimer();
            dtCuracion.Interval = TimeSpan.FromMilliseconds(50);
            dtCuracion.Tick += bajarVida;
            dtCuracion.Start();
            this.im_lucha.Opacity = 0.5;
        }
        private void bajarVida(object sender, object e)
        {
            if (pb_escudo.Value <= 100 || pb_escudo.Value >= 0)
            {
                this.pb_escudo.Value -= 0.5;
                controlE -= 0.5;
                if (controlE == 0)
                {
                    this.dtCuracion.Stop();
                    this.im_lucha.Opacity = 1;
                    controlE = 30;
                }
                else if (pb_escudo.Value <= 0 && pb_vida.Value > 0)
                {
                    controlC = controlC - controlE;
                    if (pb_vida.Value <= 100 || pb_vida.Value > 0)
                    {
                        this.pb_vida.Value -= 0.5;
                        controlC -= 0.5;
                        colorVida();
                        if (pb_vida.Value <= 20)
                        {
                            this.im_ojoDer.Visibility = Visibility.Visible;
                            this.im_ojoIzq.Visibility = Visibility.Visible;
                            this.OjoDerecho.Visibility = Visibility.Collapsed;
                            this.OjoIzquierdo.Visibility = Visibility.Collapsed;
                        }
                        if (controlC == 0 || pb_vida.Value == 1)
                        {
                            this.dtCuracion.Stop();
                            controlC = 30;
                            if (pb_vida.Value == 1)
                            {
                                this.dtCuracion.Stop();
                                this.im_lucha.Opacity = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
