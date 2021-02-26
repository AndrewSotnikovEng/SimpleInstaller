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
        private string rawCmd;

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
        public string RawCmd { get => rawCmd; set
            {
                rawCmd = value;
                OnPropertyChanged("RawCmd");
            }
            }
        public bool IsChecked { get; set; }

        public Item(string name, string url, string rawCmd, bool isChecked = false)
        {
            Name = name;
            Url = url;
            RawCmd = rawCmd;
            IsChecked = isChecked;
        }
    }
}
