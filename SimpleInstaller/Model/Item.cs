using SimpleInstaller.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInstaller.Model
{
    [Table("Items")]
    public class Item : ModelBase
    {

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        string name;
        string url;
        string rawCommand;

        [Column("NAME")]
        public string Name { get => name; set { 
                name = value;
                OnPropertyChanged("Name");
            } 
        }

        [Column("URL")]
        public string Url { get => url; set
            {
                url = value;
                OnPropertyChanged("Url");
            }
            }

        [Column("RAW_COMMAND")]
        public string RawCommand { get => rawCommand; set
            {
                rawCommand = value;
                OnPropertyChanged("RawCommand");
            }
            }

        [NotMapped]
        public bool IsChecked { get; set; }

        public Item(string name, string url, string rawCommand, bool isChecked = false)
        {
            Name = name;
            Url = url;
            RawCommand = rawCommand;
            IsChecked = isChecked;
        }

        public Item()
        {

        }
    }
}
