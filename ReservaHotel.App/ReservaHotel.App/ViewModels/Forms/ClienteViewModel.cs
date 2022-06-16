using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using ReservaHotel.App.DTOs;
using Xamarin.Forms;

namespace ReservaHotel.App.ViewModels.Forms
{
    public class ClienteViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<ClienteItemViewModel> _clientes;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<ClienteItemViewModel> Clientes
        {
            get { return _clientes; }
            set { this.SetValue(ref _clientes, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods
        async void GetClientes()
        {
            this.IsRefreshing = true;
            var url = "https://62a672f5430ba53411d4cfc0.mockapi.io/api/reservahotel/cliente";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var clientes = JsonConvert.DeserializeObject<ObservableCollection<ClienteItemViewModel>>(result);
                    this.Clientes = clientes;
                }
            }
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public Command RefreshCommand { get; set; }
        #endregion

        public ClienteViewModel()
        {
            this.RefreshCommand = new Command(GetClientes);
            this.RefreshCommand.Execute(null);
        }
    }

}
