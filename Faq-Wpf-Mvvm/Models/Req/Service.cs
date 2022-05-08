using Faq_Wpf_Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Faq_Wpf_Mvvm
{
    public class Service
    {
        public static Context db = new Context();
        private static User clientSession = new User();
        public static Frame frame;
        public static User ClientSession
        {
            get => clientSession;
            set => clientSession = value;

        }
    }
}
