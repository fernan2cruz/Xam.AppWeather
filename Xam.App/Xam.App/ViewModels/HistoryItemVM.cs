namespace Xam.App.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xam.App.Data.Entities;

    public class HistoryItemVM : WeatherHistoric
    {
        public ICommand SelectCityCommand => new RelayCommand(SelectCity);
        private void SelectCity()
        {
            MainViewModel.GetInstance().SearchString = this.City;

        }
    }
}
