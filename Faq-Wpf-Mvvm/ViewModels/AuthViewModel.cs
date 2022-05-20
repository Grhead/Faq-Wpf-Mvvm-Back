using Faq_Wpf_Mvvm.Models;
using Faq_Wpf_Mvvm.Views;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class AuthViewModel : StaticViewModel
    {
        private string _login;
        private string _password;
        private RelayCommand _applyBtn;
        public string Login { get { return _login; } set { _login = value; } }
        public RelayCommand ApplyBtn => _applyBtn ?? (_applyBtn = new RelayCommand(x =>
        {
            var passwordBox = x as PasswordBox;
            var password = passwordBox.Password;
            User tempAuth = Service.db.Users.FirstOrDefault(x => x.Login == Login && x.Password == password);
            if (tempAuth != null)
            {
                Service.ClientSession = tempAuth;
                Service.frame.Navigate(new ProfilePage());
            }
        }));
        
    }
}
