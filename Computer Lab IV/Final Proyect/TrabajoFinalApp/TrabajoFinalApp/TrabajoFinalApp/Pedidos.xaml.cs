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
    public partial class Pedidos : ContentPage
    {
        public Pedidos()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            cargarPedidos();

        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
             
        private async void listPedidos_ItemTapped(object sender, ItemTappedEventArgs e)
        {                    
            //No se muestra el item seleccionado
            ((ListView)sender).SelectedItem = null;

            //Se redirecciona a la pagina Editar Pedido con el pedido seleccionado
            await Navigation.PushModalAsync(new EditarPedido((PedidoVenta)e.Item));            
        }       


        private void cargarPedidos()
        {
            List<PedidoVenta> pedidos = new List<PedidoVenta>();

            PedidoVenta p1 = new PedidoVenta();
            p1.NroPedido = 1;
            p1.Cliente = "Enzo Panettieri";
            p1.Estado = "Entregado";
            p1.MontoTotal = 25000;

            PedidoVenta p2 = new PedidoVenta();
            p2.NroPedido = 2;
            p2.Cliente = "Luigi Panettieri";
            p2.Estado = "Enviado";
            p2.MontoTotal = 4000;

            pedidos.Add(p1);
            pedidos.Add(p2);            

            listPedidos.ItemsSource = pedidos;
        }

        
    }
}
