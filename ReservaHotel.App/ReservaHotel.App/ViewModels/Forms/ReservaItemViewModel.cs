using ReservaHotel.App.DTOs;
using ReservaHotel.App.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace ReservaHotel.App.ViewModels.Forms
{
    public class ReservaItemViewModel : ReservaDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.reservaID}", "Cancel");

            ReservaDetailPage detailPage = new ReservaDetailPage();
            detailPage.BindingContext = new ReservaDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }
        public Command OnItemClickCommand { get; set; }

        public ReservaItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
