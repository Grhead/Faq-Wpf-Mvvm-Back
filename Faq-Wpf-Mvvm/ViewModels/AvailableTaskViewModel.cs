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
    public class AvailableTaskViewModel : StaticViewModel
    {
        public AvailableTaskViewModel()
        {
            ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Include(x => x.Status).Where(x => x.StatusId == 1));
        }
        private ObservableCollection<TaskX> _listOfTasks = new ObservableCollection<TaskX>();
        public ObservableCollection<TaskX> ListOfTasks
        {
            get { return _listOfTasks; }
            set { _listOfTasks = value; OnPropertyChanged(); }
        }
    }
}
