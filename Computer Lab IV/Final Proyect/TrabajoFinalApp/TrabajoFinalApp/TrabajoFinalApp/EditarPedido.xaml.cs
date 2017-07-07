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
            cargarDetalles();
        }

        public void cargarDetalles()
        {
            List<PedidoVentaDetalleTabla> detalles = new List<PedidoVentaDetalleTabla>();

            PedidoVentaDetalleTabla pedido1 = new PedidoVentaDetalleTabla(2, "Lavandina", 20.0, 0, 40.0);
            PedidoVentaDetalleTabla pedido2 = new PedidoVentaDetalleTabla(3, "Jabon", 10, 0, 30.0);

            detalles.Add(pedido1);
            detalles.Add(pedido2);

            listDetalles.ItemsSource = detalles;

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {

        }

        private async void listDetalles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //No se muestra el item seleccionado
            ((ListView)sender).SelectedItem = null;

            //Se redirecciona a la pagina Editar Pedido con el pedido seleccionado
            await Navigation.PushModalAsync(new EditarDetalle());
        }
    }
}
