using Faq_Wpf_Mvvm.ViewModels;
using Faq_Wpf_Mvvm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Faq_Wpf_Mvvm
{
    public class NavigationViewModel : StaticViewModel
    {
        public NavigationViewModel()
        {
            Service.frame.Navigate(new AuthPage());
        }
        private RelayCommand _clearSes;
        public RelayCommand ClearSession => _clearSes ?? (_clearSes = new RelayCommand(x =>
        {
            Service.ClientSession = null;
            Service.frame.Navigate(new AuthPage());
        }));
        private RelayCommand _navigationCommand;
        public RelayCommand NavigationCommand => _navigationCommand ?? (_navigationCommand = new RelayCommand(x =>
        {
            string a = x.ToString();
            switch (a)
            {
                case "reg":
                    Service.frame.Navigate(new RegistrePage());
                    break;
                case "prof":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new ProfilePage());
                    }
                    break;
                case "ulist":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new ViewUsersPage());
                    }
                    break;
                case "tlist":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new AvailableTaskPage());
                    }
                    break;
                case "scre":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new GetTaskPage());
                    }
                    break;
                case "hist":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new HistoryPage());
                    }
                    break;
                case "stat":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new ChangeStatusPage());
                    }
                    break;
                case "filt":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new FilterPage());
                    }
                    break;
                case "find":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new FindPage());
                    }
                    break;
                case "crea":
                    if (Service.ClientSession.Login != null)
                    {
                        Service.frame.Navigate(new CreateTaskPage());
                    }
                    break;
            }   
        }));
    }
}
