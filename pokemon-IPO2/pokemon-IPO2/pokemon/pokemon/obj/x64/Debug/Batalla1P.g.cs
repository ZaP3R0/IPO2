﻿#pragma checksum "C:\Users\Usuario\Desktop\trabajos y practicas\pokemon-IPO2\pokemon\pokemon\Batalla1P.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "95C8CBFE4086B6228075D66B8F7244231B5D7A8F1D8B0F60EF4E029D40C7886E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pokemon
{
    partial class Batalla1P : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Batalla1P.xaml line 26
                {
                    this.ventanaIzq = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 3: // Batalla1P.xaml line 28
                {
                    this.VentanaDer = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 4: // Batalla1P.xaml line 30
                {
                    this.jugador1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Batalla1P.xaml line 31
                {
                    this.jugador2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Batalla1P.xaml line 34
                {
                    this.atacar1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.atacar1).Click += this.atacar1_Click;
                }
                break;
            case 7: // Batalla1P.xaml line 36
                {
                    this.subirAtaque1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.subirAtaque1).Click += this.subirAtaque1_Click;
                }
                break;
            case 8: // Batalla1P.xaml line 37
                {
                    this.Curar1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Curar1).Click += this.Curar1_Click;
                }
                break;
            case 9: // Batalla1P.xaml line 38
                {
                    this.rendirse = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.rendirse).Click += this.rendirse_Click;
                }
                break;
            case 10: // Batalla1P.xaml line 42
                {
                    this.rectangulo1 = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 11: // Batalla1P.xaml line 43
                {
                    this.turnoJugador1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // Batalla1P.xaml line 44
                {
                    this.rectangulo2 = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 13: // Batalla1P.xaml line 45
                {
                    this.turnoJugador2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Batalla1P.xaml line 46
                {
                    this.atras = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)this.atras).PointerReleased += this.atras_PointerReleased;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

