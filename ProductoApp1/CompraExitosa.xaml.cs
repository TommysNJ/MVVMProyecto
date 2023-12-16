using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1;

public partial class CompraExitosa : ContentPage
{
	public CompraExitosa()
	{
		InitializeComponent();
	}
	private readonly APIService _APIService;
	Usuario usuarioLogin;
	public CompraExitosa(APIService apiservice, Usuario usuario = null)
	{
		usuarioLogin = usuario;
		InitializeComponent();
		_APIService = apiservice;


	}

    private async void OnClickVolverList(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopToRootAsync();


        await Application.Current.MainPage.Navigation.PushAsync(new ListaProductos(_APIService, usuarioLogin));
    }

}