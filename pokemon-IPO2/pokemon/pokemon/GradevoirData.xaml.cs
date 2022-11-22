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






// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace pokemon
{
    public sealed partial class GardevoirData : UserControl
    {
        List<Pokemon> listaPokemon = new List<Pokemon>();
        Pokedex pokedex;

        public GardevoirData(Int32 n_boton, Pokedex pokedexx)
        {
            this.InitializeComponent();
            listaPokemon = CargarContenidoXML();
            Pokemon pokemon = obtenerDatosPoke(n_boton);
            pokedex = pokedexx;
            DataContext = pokemon;
        }

        private Pokemon obtenerDatosPoke(int n_boton)
        {
            String pokeNombre = null;
            switch (n_boton)
            {
                case 1:
                    pokeNombre = "Gardevoir";
                    break;
                case 2:
                    pokeNombre = "Dragonite";
                    break;
                case 3:
                    pokeNombre = "Jigglypuff";
                    break;
                case 4:
                    pokeNombre = "Zapdos";
                    break;
                case 5:
                    pokeNombre = "Charizard";
                    break;
                case 6:
                    pokeNombre = "Onix";
                    break;
            }
            Pokemon pokemonElegido = null;

            foreach (Pokemon p in listaPokemon)
            {
                if (p.Nombre == pokeNombre)
                {
                    pokemonElegido = p;
                }
            }

            t_nombre.Text = pokemonElegido.Nombre;
            t_desc.Text = pokemonElegido.descripcion;
            t_altura.Text = pokemonElegido.altura;
            t_peso.Text = pokemonElegido.peso;
            t_tipo.Text = pokemonElegido.tipo;
            return pokemonElegido;

        }

        private List<Pokemon> CargarContenidoXML()
        {
            List<Pokemon> listadoPoke = new List<Pokemon>();
            XmlDocument docSol = new XmlDocument();
            docSol.Load("listaPokemon.xml");
            foreach (XmlNode node in docSol.DocumentElement.ChildNodes)
            {
                var nuevoPokemon = new Pokemon("", "", "", "", "", "");
                nuevoPokemon.Nombre = node.Attributes["nombre"].Value;
                nuevoPokemon.tipo = node.Attributes["tipo"].Value;
                nuevoPokemon.altura = node.Attributes["altura"].Value;
                nuevoPokemon.peso = node.Attributes["peso"].Value;
                nuevoPokemon.imagen = node.Attributes["imag"].Value;
                nuevoPokemon.descripcion = node.Attributes["descripcion"].Value;
                listadoPoke.Add(nuevoPokemon);

            }
            return listadoPoke;
        }

        private void Image_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pokedex.abrirNumeroJugadores();
        }
    }
}
