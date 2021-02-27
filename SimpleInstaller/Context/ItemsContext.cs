using SimpleInstaller.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInstaller.Context
{
    public class ItemsContext : DbContext
    {
        public ItemsContext() : base("DefaultConnection")
        {
        }
        public DbSet<Item> Items { get; set; }


    }
}
