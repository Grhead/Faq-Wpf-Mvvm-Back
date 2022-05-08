using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class ProfileViewModel : StaticViewModel
    {
        public ProfileViewModel()
        {
            NameTextBlock = Service.ClientSession.FirstName;
            SurnameTextBlock = Service.ClientSession.SecondName;
            LastNameTextBlock = Service.ClientSession.LastName;
            LoginTextBlock = Service.ClientSession.Login;
            TaskCountGet = Service.db.TaskXes.Count(x => x.UsersGetId == Service.ClientSession.Id);
            TaskCountSet = Service.db.TaskXes.Count(x => x.UsersSetId == Service.ClientSession.Id);
        }
        public string NameTextBlock { get; set; }
        public string SurnameTextBlock { get; set; }
        public string LastNameTextBlock { get; set; }
        public string LoginTextBlock { get; set; }
        private int _taskCountGet;
        public int TaskCountGet
        {
            get { return _taskCountGet; }
            set { _taskCountGet = value; OnPropertyChanged(); }
        }
        private int _taskCountSet;
        public int TaskCountSet
        {
            get { return _taskCountSet; }
            set { _taskCountSet = value; OnPropertyChanged(); }
        }
    }
}
