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
    public class ChangeStatusViewModel : StaticViewModel
    {
        public ChangeStatusViewModel()
        {
            ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Include(x => x.Status).Where(x => x.StatusId == 2 && x.UsersSetId == Service.ClientSession.Id).Include(x => x.UsersSet));
        }

        private ObservableCollection<TaskX> _listOfTasks;
        public ObservableCollection<TaskX> ListOfTasks
        {
            get { return _listOfTasks; }
            set { _listOfTasks = value; OnPropertyChanged(); }
        }
        private bool _ica;
        public bool Ica { get { return _ica; } set { _ica = value; OnPropertyChanged(); } }

        public TaskX SelectedItem { get; set; }

        private RelayCommand _applyAnswer;
        public RelayCommand ApplyAnswer => _applyAnswer ?? (_applyAnswer = new RelayCommand(x =>
        {
            var temp = SelectedItem;
            temp.StatusId = 3;
            Service.db.SaveChanges();
            ListOfTasks = new ObservableCollection<TaskX>(Service.db.TaskXes.Include(x => x.Status).Where(x => x.StatusId == 2 && x.UsersSetId == Service.ClientSession.Id).Include(x => x.UsersSet));

        }));
    }
}
