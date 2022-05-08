using Faq_Wpf_Mvvm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class FindViewModel : StaticViewModel
    {
        public FindViewModel()
        {
            ListOfUsers = new ObservableCollection<User>(Service.db.Users);
            ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Include(x => x.Status).Include(x => x.UsersSet));
        }
        private ObservableCollection<User> _listOfUsers;
        private ObservableCollection<TaskX> _listOfTasks;
        public ObservableCollection<User> ListOfUsers
        {
            get { return _listOfUsers; }
            set { _listOfUsers = value;}
        }
        public ObservableCollection<TaskX> ListOfTasks
        {
            get { return _listOfTasks; }
            set { _listOfTasks = value;}
        }
        private string _userLoginGet;
        public string UserLoginGet
        {
            get { return _userLoginGet; }
            set { _userLoginGet = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TaskX> _toViewList;
        public ObservableCollection<TaskX> ToViewList
        {
            get { return _toViewList; }
            set { _toViewList = value; OnPropertyChanged(); }
        }
        private RelayCommand _findTasksCommand;
        public RelayCommand FindTasksCommand => _findTasksCommand ?? (_findTasksCommand = new RelayCommand(x =>
        {
            var tempLogin = ListOfUsers.FirstOrDefault(x => x.Login == UserLoginGet)?.Id;
            if (tempLogin != null)
            {
                ToViewList = new ObservableCollection<TaskX>(ListOfTasks.Where(x => x.UsersSetId == tempLogin));
            }
        }));
    }
}
