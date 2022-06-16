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
    public class ReservaDetailViewModel : BaseViewModel
    {
        #region Attributes
        private ReservaDTO _reserva;
        private ObservableCollection<HabitacionDTO> _habitacion;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ReservaDTO Reserva
        {
            get { return _reserva; }
            set { this.SetValue(ref _reserva, value); }
        }

        public ObservableCollection<HabitacionDTO> Habitacion
        {
            get { return _habitacion; }
            set { this.SetValue(ref _habitacion, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion


        async void GetHabitacion()
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
                    var habitacion = JsonConvert.DeserializeObject<ObservableCollection<HabitacionItemViewModel>>(result);
                    var habitacionFilter = habitacion.Where(x => x.habitacionID == _reserva.habitacionID).ToList();
                    this.Habitacion = new ObservableCollection<ReservaDTO>(habitacionFilter);
                }
            }
            this.IsRefreshing = false;
        }

        public ReservaDetailViewModel(ReservaDTO reserva)
        {
            this.Reserva = reserva;
            this.RefreshCommand = new Command(GetHabitacion);
            this.RefreshCommand.Execute(null);

        }
        public ReservaDetailViewModel()
        {

        }



        public Command RefreshCommand { get; set; }

    }
}
}
