namespace Xam.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Xam.App.Data.Entities;
    

    public class MenuViewModel : BaseViewModel
    {       
        public MenuViewModel()
        {
            MainViewModel.GetInstance().MenuViewModel = this;
            loadMenu();
        }

        private void loadMenu()
        {
            var listMenu = new List<MenuItemVM>()
            {
                new MenuItemVM
                {
                    Imgs ="Menu1",
                    Title = "Sweet Chili Beef & Vegetable Stir-Fry",
                    SubTitle ="With Garlic Rice"
                },
                 new MenuItemVM
                {
                    Imgs ="Menu2",
                    Title = "Sweet Chili Beef & Vegetable Stir-Fry",
                    SubTitle ="With Garlic Rice"
                },
                  new MenuItemVM
                {
                    Imgs ="Menu3",
                    Title = "Sweet Chili Beef & Vegetable Stir-Fry",
                    SubTitle ="With Garlic Rice"
                }
            };
            MainViewModel.GetInstance().MenuItemVM = new ObservableCollection<MenuItemVM>(listMenu);
        }
    }
}
