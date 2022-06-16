using ReservaHotel.App.DTOs;
using ReservaHotel.App.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReservaHotel.App.ViewModels.Forms
{
    public class HabitacionItemViewModel : HabitacionDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.habitacionID}", "Cancel");

            HabitacionDetailPage detailPage = new HabitacionDetailPage();
            detailPage.BindingContext = new HabitacionDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }
        public Command OnItemClickCommand { get; set; }

        public HabitacionItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
