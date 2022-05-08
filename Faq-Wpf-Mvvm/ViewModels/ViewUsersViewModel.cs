using Faq_Wpf_Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class ViewUsersViewModel : StaticViewModel
    {
        public ViewUsersViewModel()
        {
            ListOfUsers = new ObservableCollection<User>(Service.db.Users);
        }
        private ObservableCollection<User> _listOfUsers;
        public ObservableCollection<User> ListOfUsers
        {
            get { return _listOfUsers; }
            set { _listOfUsers = value; OnPropertyChanged();  }
        }
    }
}
