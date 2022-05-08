using Faq_Wpf_Mvvm.Models;
using Faq_Wpf_Mvvm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class RegistreViewModel : StaticViewModel
    {
        public string NameTextBlock { get; set; }
        public string SurnameTextBlock { get; set; }
        public string LastNameTextBlock { get; set; }
        public string LoginTextBlock { get; set; }
        public string FirstPassword { get; set; }
        public string SecondPassword { get; set; }
        private RelayCommand _regCommand;
        public RelayCommand RegCommand => _regCommand ?? (_regCommand = new RelayCommand(x =>
        {
            User NewUser = new User();
            string cl = LoginTextBlock;
            User CheckLogin = Service.db.Users.FirstOrDefault(x => x.Login == LoginTextBlock);
            if (CheckLogin == null)
            {
                if (NameTextBlock != null && LastNameTextBlock != null && SurnameTextBlock != null && LoginTextBlock != null && FirstPassword != null)
                {
                    NewUser.FirstName = NameTextBlock;
                    NewUser.LastName = LastNameTextBlock;
                    NewUser.SecondName = SurnameTextBlock;
                    NewUser.Login = LoginTextBlock;
                    string fp = FirstPassword;
                    string sp = SecondPassword;
                    if (fp == sp)
                    {
                        NewUser.Password = FirstPassword;
                        Service.db.Users.Add(NewUser);
                        Service.db.SaveChanges();
                        Service.frame.Navigate(new AuthPage());
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не заполнили все поля");
                }
            }
            else
            {

                MessageBox.Show("Login занят");

            }
        }));
    }
}
