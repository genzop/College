using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinalApp.Controladores;
using TrabajoFinalApp.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoFinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedidos : ContentPage
    {

        protected List<PedidoVenta> listaPedidos;        
        private int IdVendedor { get; set; }

        public Pedidos(int idVendedor)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Se guarda el id del vendedor que se le logueo
            this.IdVendedor = idVendedor;
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
            await Navigation.PushModalAsync(new EditarPedido((PedidoVenta)e.Item, this.IdVendedor));            
        }       

        private void imgExportar_Tapped(object sender, EventArgs e)
        {

        }

        private async void imgInsertar_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditarPedido(null, this.IdVendedor));
        }

        private void cargarPedidos()
        {
            //Se cargan los pedidos correspondientes a ese vendedor
            using (var pedControlador = new ControladorPedidoVenta())
            {
                this.listaPedidos = pedControlador.FindByVendedor(this.IdVendedor);
            }

            listPedidos.ItemsSource = listaPedidos;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            cargarPedidos();
        }
    }
}
