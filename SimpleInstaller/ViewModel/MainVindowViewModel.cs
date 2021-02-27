using SimpleInstaller.Commands;
using SimpleInstaller.Context;
using SimpleInstaller.Model;
using SimpleInstaller.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInstaller.ViewModel
{
    class MainVindowViewModel : ViewModelBase
    {
        public RelayCommand ShowNewItemWinCmd;
        private Item selectedItem;

        public RelayCommand SwitchToViewerCmd { get; }
        public RelayCommand SwitchToEditorCmd { get; }

        public Item SelectedItem { get => selectedItem; set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public MainVindowViewModel()
        {

            Items.Add(new Item("Notepad ++", "url1", "cmd1"));
            Items.Add(new Item("Victoria", "url2", "cmd2"));
            Items.Add(new Item("Firefox", "url3", "cmd3"));
            Items.Add(new Item("Eclipse", "url4", "cmd4"));

            MessengerStatic.SelectedItemUpdated += UpdateSelectedItem;
            MessengerStatic.MainWinListBoxClicked += SendSelectedItem;

            ShowNewItemWinCmd = new RelayCommand(o => { ShowNewItemWin(); }, ShowNewItemWinCanExecute);
            SwitchToViewerCmd = new RelayCommand(o => { SwitchToViewer(); }, SwtichToViewerCanExecute);
            SwitchToEditorCmd = new RelayCommand(o => { SwtichToEditor(); }, SwitchToEditorCanExecute);

            loadData();

        }

        void loadData()
        {
            ItemsContext db = new ItemsContext();



            
            db.Items.Add(new Item("Some element", "url", "new url"));

            db.SaveChanges();

        }

        

        private void SendSelectedItem(object obj)
        {
            if (!isViewerMode)
            {
                MessengerStatic.NotifySelectedItemInitializing(SelectedItem);
            }
        }

        private void UpdateSelectedItem(object obj)
        {
            SelectedItem = (Item)obj;
        }

  

        private bool SwitchToEditorCanExecute(object arg)
        {
            bool result = isViewerMode ? true : false;

            return result;
        }

        private void SwitchToViewer()
        {
            isViewerMode = true;
        }

        private void SwtichToEditor()
        {
            isViewerMode = false;
        }

        private bool SwtichToViewerCanExecute(object arg)
        {
            bool result = !isViewerMode ? true : false;

            return result;
        }

        public bool isViewerMode { get; set; } = true;

        private bool ShowNewItemWinCanExecute(object arg)
        {
            return true;
        }

        private void ShowNewItemWin()
        {
            throw new NotImplementedException();
        }

        public string Label { get; set; } = "label";
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
    }
}
