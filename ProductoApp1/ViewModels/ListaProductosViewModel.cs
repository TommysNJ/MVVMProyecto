using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1.ViewModels
{
        public partial class ListaProductosViewModel : ObservableObject
        {

            private APIService _ApiService;
            [ObservableProperty]
            public ObservableCollection<Producto> listaProductos;


            public ListaProductosViewModel()
            {
            }

            public void SetApiService(APIService apiservice)
            {
                _ApiService = apiservice;
            }

            public async void ProductosAsync()
            {

                ListaProductos = new ObservableCollection<Producto>();
                var productos = await _ApiService.GetProductos();
                foreach (var p in productos)
                {
                    ListaProductos.Add(p);
                }

            }

        }
}

