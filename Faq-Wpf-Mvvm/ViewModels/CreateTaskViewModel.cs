using Faq_Wpf_Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faq_Wpf_Mvvm.ViewModels
{
    public class CreateTaskViewModel : StaticViewModel
    {
        private string _title;
        private string _description;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }
        private RelayCommand _createTaskCommand;
        public RelayCommand CreateTaskCommand => _createTaskCommand ?? (_createTaskCommand = new RelayCommand(x =>
        {
            if (Title != null && Description != null)
            {
                TaskX NewTask = new TaskX();
                var check = Service.db.TaskXes.Contains(NewTask);
                NewTask.Title = Title;
                NewTask.Description = Description;
                NewTask.StatusId = 1;
                NewTask.UsersSetId = Service.ClientSession.Id;
                Service.db.TaskXes.Add(NewTask);
                Service.db.SaveChanges();
                Title = null;
                Description = null;
            }
            
        }));
    }
}
