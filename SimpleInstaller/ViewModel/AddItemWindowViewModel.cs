using SimpleInstaller.Commands;
using SimpleInstaller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInstaller.ViewModel
{
    class AddItemWindowViewModel : ViewModelBase
    {
        private string name;
        private string url;
        private string rawCommand;

        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }
        public string Url { get => url; set { url = value; OnPropertyChanged("Url"); } }
        public string RawCommand { get => rawCommand; set { rawCommand = value; OnPropertyChanged("RawCommand"); } }

        Item SelectedItem { get; set; }
        public RelayCommand UpdateItemCmd { get; }

        public AddItemWindowViewModel()
        {
            MessengerStatic.SelectedItemSent += AssignSelectedItem;

            UpdateItemCmd = new RelayCommand(o => { UpdateItem(); }, UpdateImteCanExecute);
        }

        private bool UpdateImteCanExecute(object arg)
        {
            return true;
        }

        private void UpdateItem()
        {
            SelectedItem.Name = Name;
            SelectedItem.Url = Url;
            SelectedItem.RawCommand = RawCommand;
            MessengerStatic.NotifySelectedItemUpdating(SelectedItem);
            MessengerStatic.NotifyAddItemWindowClosed(null);
        }

        private void AssignSelectedItem(object obj)
        {
            SelectedItem = (Item)obj;
            Name = SelectedItem.Name;
            Url = SelectedItem.Url;
            RawCommand = SelectedItem.RawCommand;

        }
    }
}
