using Newtonsoft.Json;
using ReservaHotel.App.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ReservaHotel.App.ViewModels.Forms
{
    public class ClienteDetailViewModel : BaseViewModel
    {
        #region Attributes
        private ClienteDTO _clientes;
        private ObservableCollection<ReservaDTO> _reserva;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ClienteDTO Cliente
        {
            get { return _clientes; }
            set { this.SetValue(ref _clientes, value); }
        }

        public ObservableCollection<ReservaDTO> Reserva
        {
            get { return _reserva; }
            set { this.SetValue(ref _reserva, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion


        async void GetReserva()
        {
            this.IsRefreshing = true;

            var url = "";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var reserva = JsonConvert.DeserializeObject<ObservableCollection<ReservaItemViewModel>>(result);
                    var reservaFilter = reserva.Where(x => x.clienteID == _clientes.clienteID).ToList();
                    this.Reserva = new ObservableCollection<ReservaDTO>(reservaFilter);
                }
            }
            this.IsRefreshing = false;
        }

        public ClienteDetailViewModel(ClienteDTO cliente)
        {
            this.Cliente = cliente;
            this.RefreshCommand = new Command(GetReserva);
            this.RefreshCommand.Execute(null);
            
        }
        public ClienteDetailViewModel()
        {

        }

        

        public Command RefreshCommand { get; set; }
        
    }
}
