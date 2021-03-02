using SimpleInstaller.Commands;
using SimpleInstaller.Context;
using SimpleInstaller.Model;
using SimpleInstaller.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleInstaller.ViewModel
{
    class MainVindowViewModel : ViewModelBase
    {
        public RelayCommand ShowNewItemWinCmd;
        private Item selectedItem;

        ItemsContext db = new ItemsContext();

        public RelayCommand SwitchToViewerCmd { get; }
        public RelayCommand SwitchToEditorCmd { get; }
        public RelayCommand AddListBoxItemCmd { get; }
        public RelayCommand EditListBoxItemCmd { get; }
        public RelayCommand DeleteListBoxItemCmd { get; }
        public RelayCommand RunInstallationCmd { get; }
        public RelayCommand QuitCmd { get; }

        public Item SelectedItem
        {
            get => selectedItem; set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public Visibility EditModeVisibilty { get => editModeVisibilty; set
            {
                editModeVisibilty = value;
                OnPropertyChanged("EditModeVisibilty");
            }
        }

        public MainVindowViewModel()
        {

            MessengerStatic.SelectedItemUpdated += UpdateSelectedItem;
            MessengerStatic.MainWinListBoxClicked += SendSelectedItem;

            ShowNewItemWinCmd = new RelayCommand(o => { ShowNewItemWin(); }, ShowNewItemWinCanExecute);
            SwitchToViewerCmd = new RelayCommand(o => { SwitchToViewer(); }, SwtichToViewerCanExecute);
            SwitchToEditorCmd = new RelayCommand(o => { SwtichToEditor(); }, SwitchToEditorCanExecute);

            AddListBoxItemCmd = new RelayCommand(o => { AddItem(); }, AddItemCanExecute);
            EditListBoxItemCmd = new RelayCommand(o => { EidtItem(); }, EditItemCanExecute);
            DeleteListBoxItemCmd = new RelayCommand(o => { DeleteItem(); }, DeleteItemCanExecute);


            RunInstallationCmd = new RelayCommand(o => { RunInstallation(); }, RunInstallationCanExecute);
            QuitCmd = new RelayCommand(o => { Quit(); }, QuitCanExecute);

            LoadData();



        }

        private bool QuitCanExecute(object arg)
        {
            return true;
        }

        private void Quit()
        {
            MessengerStatic.NotifyMainWindowClosed(null);
        }

        private bool RunInstallationCanExecute(object arg)
        {
            bool result = isViewerMode ? true : false;

            return result;
        }

        private void RunInstallation()
        {
            throw new NotImplementedException();
        }

        private bool AddItemCanExecute(object arg)
        {
            return true;
        }

        private void AddItem()
        {
            SelectedItem = new Item("", "", "");
            db.Items.Add(SelectedItem);
            MessengerStatic.NotifySelectedItemInitializing(SelectedItem);
            db.SaveChanges();
        }

        private bool EditItemCanExecute(object arg)
        {
            return true;
        }

        private void EidtItem()
        {
            MessengerStatic.NotifySelectedItemInitializing(SelectedItem);
        }

        private bool DeleteItemCanExecute(object arg)
        {
            return true;
        }

        private void DeleteItem()
        {
            db.Items.Remove(SelectedItem);
            db.SaveChanges();
        }

        void LoadData()
        {
            db.Items.Load();
            Items = db.Items.Local.ToBindingList();

            //db.Items.Add(new Item("First item","",""));
            //db.Items.Add(new Item("Second item", "", ""));
            //db.Items.Add(new Item("Third item", "", ""));
            //db.Items.Add(new Item("Fourth item", "", ""));
            //db.Items.Add(new Item("Fifth item", "", ""));


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
            db.SaveChanges();

            EditModeVisibilty = Visibility.Hidden;
        }

        private void SwtichToEditor()
        {
            isViewerMode = false;
            EditModeVisibilty = Visibility.Visible;
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

        private IEnumerable<Item> items;
        private Visibility editModeVisibilty = Visibility.Hidden;

        public IEnumerable<Item> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");

            }
        }
    }
}
