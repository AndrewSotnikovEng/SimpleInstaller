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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TabsHolder.View;

namespace SimpleInstaller.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVindowViewModel();
            MessengerStatic.SelectedItemInitialized += CreateAddItemWindow;
            MessengerStatic.MainWindowClosed += CloseWin;

        }

        private void CloseWin(object obj)
        {
            this.Close();
        }

        private void MouseDoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                MessengerStatic.NotifyMainWinListBoxClicking(null);
            }
        }

        private void CreateAddItemWindow(object obj)
        {
            AddItemWindow addItemWindow = new AddItemWindow();
            addItemWindow.Show();
            MessengerStatic.NotifySelectedItemSending(obj);
        }
     


        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
