using Faq_Wpf_Mvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Faq_Wpf_Mvvm.Views
{
    /// <summary>
    /// Логика взаимодействия для ChangeStatusPage.xaml
    /// </summary>
    public partial class ChangeStatusPage : Page
    {
        public ChangeStatusPage()
        {
            InitializeComponent();
            DataContext = new ChangeStatusViewModel();
        }
    }
}
