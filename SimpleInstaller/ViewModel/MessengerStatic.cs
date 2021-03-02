using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInstaller.ViewModel
{
    public static class MessengerStatic
    {
        public static event Action<object> MainWinListBoxClicked;
        public static void NotifyMainWinListBoxClicking(object o)
            => MainWinListBoxClicked?.Invoke(o);


        //sending selected item from MainWinVM to Code-behind
        public static event Action<object> SelectedItemInitialized;
        public static void NotifySelectedItemInitializing(object o)
            => SelectedItemInitialized?.Invoke(o);


        //sending selected item from MainWin code behind
        //to AddItemWinVM
        public static event Action<object> SelectedItemSent;
        public static void NotifySelectedItemSending(object o)
            => SelectedItemSent?.Invoke(o);



        public static event Action<object> AddItemWindowClosed;

        public static void NotifyAddItemWindowClosed(object o)
            => AddItemWindowClosed?.Invoke(o);



        public static event Action<object> MainWindowClosed;

        public static void NotifyMainWindowClosed(object o)
            => MainWindowClosed?.Invoke(o);



        public static event Action<object> SelectedItemUpdated;

        public static void NotifySelectedItemUpdating(object o)
            => SelectedItemUpdated?.Invoke(o);






    }
}

