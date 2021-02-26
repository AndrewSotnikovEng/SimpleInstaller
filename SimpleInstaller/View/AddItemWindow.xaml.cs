using SimpleInstaller.ViewModel;
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
using System.Windows.Shapes;

namespace SimpleInstaller.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            InitializeComponent();
            this.DataContext = new AddItemWindowViewModel();

            MessengerStatic.AddItemWindowClosed += MessengerStatic_SelectedItemUpdated;
        }


        private void MessengerStatic_SelectedItemUpdated(object obj)
        {
            this.Close();
        }
    }
}
