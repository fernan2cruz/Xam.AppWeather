namespace Xam.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using Entities;
    using GalaSoft.MvvmLight.Command;
    using Xam.App.Data;
    using Xam.App.Data.Entities;
    using Xam.App.Services;

    public class MainViewModel : BaseViewModel
    {
        #region Pattern Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Attributes
        private WeatherResponse weather;      
        private DataContext dataContext;
        private ObservableCollection<WeatherHistoric> weatherhistory;
        private bool isbusy;
        #endregion

        #region Properties

        public DataContext DataContext
        {
            get
            {
                if (dataContext == null)
                {
                    var dbpath =
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData), "myLocalDatabase.db3");

                    dataContext = new DataContext(dbpath);
                }
                return dataContext;

            }
        }
        public WeatherResponse Weather
        {
            get { return this.weather; }
            set { this.SetValue(ref this.weather, value); }

        }
        public ObservableCollection<WeatherHistoric> WeatherHistorics
        {
            get { return this.weatherhistory; }
            set { this.SetValue(ref this.weatherhistory, value); }
        }

        public Apiservice Apiservice; 

        public string SearchString { get; set; }
        public string Endpoint = $"https://api.apixu.com/v1/current.json?key=2650fe6f342443ad98f01545192803";
        public bool isBusy
        {
            get { return this.isbusy; }
            set { this.SetValue(ref this.isbusy, value); }
        }

        #endregion

        #region Commads
        public ICommand SearchCommand => new RelayCommand(Search); 
        #endregion

        public MainViewModel()
        {
            instance = this;
            this.Apiservice = new Apiservice();
            GetFromDataBase();
        }


        private void Search()
        {
            
            Apiservice.SearchWeather();
            InsertIntoDB();
            GetFromDataBase();
        }

        private void GetFromDataBase()
        {

            var historyList = DataContext.GetTodoItems()
                                         .GetAwaiter()
                                         .GetResult().Select(x =>
                                                                new WeatherHistoric()
                                                                {
                                                                    City = x.FullNameCity,
                                                                    LastConsultDate = x.LastConsultDate
                                                                }
                                                            );
            this.WeatherHistorics = new ObservableCollection<WeatherHistoric>(historyList);
            var test = "";
        }

        private void InsertIntoDB()
        {
            if (Weather == null)
            {
                App.Current.MainPage.DisplayAlert("Error", "El Objeto a Insertar esta vacio.", "OK");
                return;
            }

            try
            {
                var history = new WeatherHistoric
                {
                    City = Weather.location.name,
                    Country = Weather.location.country,
                    LastConsultDate = DateTime.UtcNow                    
                };
                this.DataContext.Insert(history);                

            }
            catch (Exception e)
            {

                App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");

            }
        }


    }
}
