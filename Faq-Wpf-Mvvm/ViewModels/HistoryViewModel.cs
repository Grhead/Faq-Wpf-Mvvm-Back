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
    public class HistoryViewModel : StaticViewModel
    {
        public HistoryViewModel()
        {
            ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Where(x => x.UsersGetId == Service.ClientSession.Id).Include(x => x.Status).Include(x => x.UsersSet));
            TaskCountGet = Service.db.TaskXes.Count(x => x.UsersGetId == Service.ClientSession.Id);
        }
        private ObservableCollection<TaskX> _listOfTasks;
        public ObservableCollection<TaskX> ListOfTasks
        {
            get { return _listOfTasks; }
            set { _listOfTasks = value; OnPropertyChanged(); }
        }
        private int _taskCountGet;
        public int TaskCountGet
        {
            get { return _taskCountGet; }
            set { _taskCountGet = value; OnPropertyChanged(); }
        }
    }
}
