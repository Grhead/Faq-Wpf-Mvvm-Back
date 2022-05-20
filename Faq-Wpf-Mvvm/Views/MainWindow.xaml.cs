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

namespace Faq_Wpf_Mvvm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialClass.Init();
            Service.frame = MainFrame;
            DataContext = new NavigationViewModel();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Service.ClientSession.Login != null)
            {
                RegisterBtn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
