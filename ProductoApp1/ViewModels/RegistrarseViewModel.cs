using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1.ViewModels
{
	public partial class RegistrarseViewModel : ObservableObject
	{
        private APIService _ApiService;
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string correo;
        [ObservableProperty]
        public string contrasena;

        public RegistrarseViewModel()
		{
		}

        public void SetApiService(APIService apiservice)
        {
            _ApiService = apiservice;
        }

        public async Task<int> OnClickRegistrarse()
        {

            if (!String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Correo) && !String.IsNullOrEmpty(Contrasena))
            {
                Usuario userLogin = await _ApiService.GetIniciarSesion(Correo,Contrasena);
                if (userLogin != null)
                {
                    return 1;
                }
                else
                {
                    Usuario user = await _ApiService.PostRegistrarse(new Usuario { Nombre = Nombre, Correo = Correo, Contrasena = Contrasena });
                    return 0;
                }
            }
            else
            {
                return 2;
            }
        }
    }
}

