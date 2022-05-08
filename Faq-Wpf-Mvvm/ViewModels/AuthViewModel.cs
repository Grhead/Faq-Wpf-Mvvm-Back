using Faq_Wpf_Mvvm.Models;
using Faq_Wpf_Mvvm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class AuthViewModel : StaticViewModel
    {
        private RelayCommand _applyBtn;
        private string _login;
        private string _password;
        public string Login { get { return _login; } set { _login = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public RelayCommand ApplyBtn => _applyBtn ?? (_applyBtn = new RelayCommand(x =>
        {
            
            User tempAuth = Service.db.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password);
            if (tempAuth != null)
            {
                Service.ClientSession = tempAuth;
                Service.frame.Navigate(new ProfilePage());
            }
        }));
    }
}
