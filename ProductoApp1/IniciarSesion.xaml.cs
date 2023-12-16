using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1;

public partial class IniciarSesion : ContentPage
{

    private Usuario _usuario;
    public IniciarSesion()
	{
		InitializeComponent();
	}

    private readonly APIService _APIService;
    public IniciarSesion(APIService apiservice)
    {  
        InitializeComponent();
        _APIService = apiservice;

    }


    public async void OnClickIniciarSesion(object sender, EventArgs e)
    {
        string correo = Correo.Text;
        string contrasena = Contrasena.Text;
        Usuario usuario = await _APIService.GetIniciarSesion(correo, contrasena);

        if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(contrasena))
        {

            if (usuario != null)
            {
                await Navigation.PushAsync(new ListaProductos(_APIService, usuario));
            }
            else
            {
                var toast = Toast.Make("aNo se encontró ninguna cuenta, revise sus credenciales.", ToastDuration.Short, 14);
                await toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("Por favor, ingrese todos los datos solicitados.", ToastDuration.Short, 14);
            await toast.Show();
        }
    }


    private async void OnClickVolverLista(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ListaProductos(_APIService, _usuario));
    }
    
}