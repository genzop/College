using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinalApp.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoFinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPedido : ContentPage
    {
        public EditarPedido(PedidoVenta pedido)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            lblTitulo.Text = "Editar Pedido";
            lblDomicilio.Text = "Editar Domicilio";
        }
    }
}
