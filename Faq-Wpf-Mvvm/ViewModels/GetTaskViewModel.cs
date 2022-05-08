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
    public class GetTaskViewModel : StaticViewModel
    {
        public GetTaskViewModel()
        {
            ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Include(x => x.Status).Where(x => x.StatusId == 1).Include(x => x.UsersSet));
        }
        private ObservableCollection<TaskX> _listOfTasks;
        public ObservableCollection<TaskX> ListOfTasks
        {
            get { return _listOfTasks; }
            set { _listOfTasks = value; OnPropertyChanged(); }
        }
        private string _userGetAnswer;
        public string UserGetAnswer
        {
            get { return _userGetAnswer; }
            set { _userGetAnswer = value; OnPropertyChanged(); }
        }
        private TaskX _selectedItem;
        public TaskX SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(); }
        }
        private RelayCommand _userConfirm;
        public RelayCommand UserConfirm => _userConfirm ?? (_userConfirm = new RelayCommand(x =>
        {
            if (UserGetAnswer != "" && ListOfTasks.Count != 0)
            {
                var ToPush = Service.db.TaskXes.FirstOrDefault(x => x.Title == SelectedItem.Title);
                ToPush.UsersGetId = Service.ClientSession.Id;
                ToPush.Answer = UserGetAnswer;
                ToPush.StatusId = 2;
                Service.db.SaveChanges();
                ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Include(x => x.Status).Where(x => x.StatusId == 1).Include(x => x.UsersSet));
                UserGetAnswer = null;
            }
        }));
    }
}
