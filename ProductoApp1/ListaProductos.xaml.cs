using CommunityToolkit.Maui.Core;
using Ejemplo1.Models;
using ProductoApp1.Services;
using System.Collections.ObjectModel;

namespace ProductoApp1;

public partial class ListaProductos : ContentPage
{
    public ListaProductos()
    {
        InitializeComponent();
    }

    private readonly APIService _APIService;

    public List<Producto> MiCarrito { get; set; }
    List<Producto> ListaProducto;
    Usuario usuarioLogin;
    public ListaProductos(APIService apiservice, Usuario usuario = null)
    {
        usuarioLogin = usuario;
        InitializeComponent();
        _APIService = apiservice;
        MiCarrito = new List<Producto>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (ListaProducto == null)
            ListaProducto = await _APIService.GetProductos();

        var productos = new ObservableCollection<Producto>(ListaProducto);
        listaProductos.ItemsSource = productos;

        CantidadCarrito.Text = MiCarrito.Sum(x => x.Cantidad).ToString();
    }



    private async void OnClickAddCard(object sender, EventArgs e)

    {
        //obtiene un producto asociado al botón
        Producto producto = (sender as Button)?.BindingContext as Producto;

        Producto addProducto = new Producto { IdProducto = producto.IdProducto, Nombre = producto.Nombre, Descripcion = producto.Descripcion, Cantidad = 1, Precio = producto.Precio };

        //busca el producto en la lista general de productos y le resta 1
        Producto productoExistencia = ListaProducto.Find(x => x.IdProducto == addProducto.IdProducto);
        productoExistencia.Cantidad--;
        var productos = new ObservableCollection<Producto>(ListaProducto);
        listaProductos.ItemsSource = productos;


        //busca el producto en el carrito
        Producto productoList = MiCarrito.Find(x => x.IdProducto == addProducto.IdProducto);

        if (productoList != null)
            productoList.Cantidad++;
        else
            MiCarrito.Add(addProducto);

        CantidadCarrito.Text = MiCarrito.Sum(x => x.Cantidad).ToString();

    }


    private async void OnClickVerCarrito(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Carrito(_APIService, MiCarrito, ListaProducto, usuarioLogin));
    }



}