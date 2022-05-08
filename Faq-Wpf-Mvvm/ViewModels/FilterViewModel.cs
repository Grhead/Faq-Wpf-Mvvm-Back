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
    public class FilterViewModel : StaticViewModel
    {
        public FilterViewModel()
        {
            ListTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Include(x => x.Status).Include(x => x.UsersSet));
        }
        private DateTime _dateStartBlock;
        private DateTime _dateEndBlock;
        public DateTime DateStartBlockSelected
        {
            get { return _dateStartBlock; }
            set { _dateStartBlock = value; }
        }
        public DateTime DateEndBlockSelected
        {
            get { return _dateEndBlock; }
            set { _dateEndBlock = value; }
        }
        private ObservableCollection<TaskX> _listOfTasks;
        public ObservableCollection<TaskX> ListTasks
        {
            get { return _listOfTasks; }
            set { _listOfTasks = value; OnPropertyChanged(); }
        }
        private ObservableCollection<TaskX> _dateTasks;
        public ObservableCollection<TaskX> DateTasks
        {
            get { return _dateTasks; }
            set { _dateTasks = value; OnPropertyChanged(); }
        }
        private RelayCommand _findButton;
        public RelayCommand FindButton => _findButton ?? (_findButton = new RelayCommand(x =>
        {
            var start = DateStartBlockSelected;
            var end = DateEndBlockSelected;
            DateTasks = new ObservableCollection<TaskX>(ListTasks.Where(x => x.Date < end && x.Date > start));
        }));
    }
}
