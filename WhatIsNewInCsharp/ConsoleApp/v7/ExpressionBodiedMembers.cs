using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v7
{
    public class Soda
    {
        private int id;
        private static readonly Dictionary<int, string> brands =
            new Dictionary<int, string>();

        public Soda(int id, string name) {
             brands.Add(id, name);
            this.id = id;
        }
        ~Soda() => brands.Remove(id);

        public string Name {
            get => brands[id]; 
            set => brands[id] = value; 
        }
    }
}
