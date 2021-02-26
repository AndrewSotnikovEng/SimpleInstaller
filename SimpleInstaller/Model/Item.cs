using SimpleInstaller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInstaller.Model
{
    class Item : ModelBase
    {
        private string name;
        private string url;
        private string rawCommand;

        public string Name { get => name; set { 
                name = value;
                OnPropertyChanged("Name");
            } 
        }
        public string Url { get => url; set
            {
                url = value;
                OnPropertyChanged("Url");
            }
            }
        public string RawCommand { get => rawCommand; set
            {
                rawCommand = value;
                OnPropertyChanged("RawCommand");
            }
            }
        public bool IsChecked { get; set; }

        public Item(string name, string url, string rawCommand, bool isChecked = false)
        {
            Name = name;
            Url = url;
            RawCommand = rawCommand;
            IsChecked = isChecked;
        }
    }
}
