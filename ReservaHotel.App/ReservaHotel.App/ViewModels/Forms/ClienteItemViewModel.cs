using ReservaHotel.App.DTOs;
using ReservaHotel.App.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReservaHotel.App.ViewModels.Forms
{
    public class ClienteItemViewModel : ClienteDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.nombreCompleto}", "Cancel");

            ClienteDetailPage detailPage = new ClienteDetailPage();
            detailPage.BindingContext = new ClienteDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }
        public Command OnItemClickCommand { get; set; }

        public ClienteItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
