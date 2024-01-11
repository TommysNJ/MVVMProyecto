using System;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1.ViewModels
{
	public partial class IniciarSesionViewModel : ObservableObject
	{
		private APIService _ApiService;
		[ObservableProperty]
		public string correo;
		[ObservableProperty]
		public string contrasena;

		public IniciarSesionViewModel()
		{
		}

		public void SetApiService(APIService apiservice)
		{
			_ApiService = apiservice;
		}

		public async Task<int> OnClickIniciarSesion()
		{
            Usuario usuario = await _ApiService.GetIniciarSesion(Correo, Contrasena);

            if (!string.IsNullOrEmpty(Correo) && !string.IsNullOrEmpty(Contrasena))
            {

                if (usuario != null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }

        public async Task<Usuario> OnClickIniciarSesionI()
        {
            Usuario usuario = await _ApiService.GetIniciarSesion(Correo, Contrasena);

            if (!string.IsNullOrEmpty(Correo) && !string.IsNullOrEmpty(Contrasena))
            {

                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
	}
}

