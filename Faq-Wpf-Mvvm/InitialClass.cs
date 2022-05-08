using Faq_Wpf_Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faq_Wpf_Mvvm
{
    public class InitialClass
    {
        public static void Init()
        {
            var user0 = new User
            {
                FirstName = "FirstName1",
                SecondName = "SecondName1",
                LastName = "LastName1",
                Login = "login1",
                Password = "password1"
            };
            var user1 = new User
            {
                FirstName = "FirstName2",
                SecondName = "SecondName2",
                LastName = "LastName2",
                Login = "login2",
                Password = "password2"
            };
            var user2 = new User
            {
                FirstName = "FirstName3",
                SecondName = "SecondName3",
                LastName = "LastName3",
                Login = "login3",
                Password = "password3"
            };
            var user3 = new User
            {
                FirstName = "FirstName4",
                SecondName = "SecondName4",
                LastName = "LastName4",
                Login = "login4",
                Password = "password4"
            };

            var task0 = new TaskX
            {
                Title = "Task#1",
                Description = "Easy Level",
                Date = new DateTime(2022, 10, 01),
                UsersSetId = 1,
                UsersGetId = 2,
                StatusId = 1,
                Answer = ""
            };
            var task1 = new TaskX
            {
                Title = "Task#2",
                Description = "Easy Level",
                Date = new DateTime(2022, 11, 09),
                UsersSetId = 2,
                UsersGetId = 1,
                StatusId = 3,
                Answer = ""
            };
            var task2 = new TaskX
            {
                Title = "Task#3",
                Description = "Hard Level",
                Date = new DateTime(2022, 06, 04),
                UsersSetId = 3,
                UsersGetId = 2,
                StatusId = 2,
                Answer = ""
            };
            var task3 = new TaskX
            {
                Title = "Task#4",
                Description = "Medium Level",
                Date = new DateTime(2022, 12, 20),
                UsersSetId = 2,
                UsersGetId = 3,
                StatusId = 2,
                Answer = ""
            };
            Service.db.Statuses.Add(new Status() { Title = "Не готово" });
            Service.db.Statuses.Add(new Status() { Title = "Выполняется" });
            Service.db.Statuses.Add(new Status() { Title = "Готово" });
            Service.db.SaveChanges();
            Service.db.Users.Add(user0);
            Service.db.Users.Add(user1);
            Service.db.Users.Add(user2);
            Service.db.Users.Add(user3);
            Service.db.SaveChanges();
            Service.db.TaskXes.Add(task0);
            Service.db.TaskXes.Add(task1);
            Service.db.TaskXes.Add(task2);
            Service.db.TaskXes.Add(task3);
            Service.db.SaveChanges();
        }
    }
}
