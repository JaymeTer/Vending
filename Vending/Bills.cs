using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Bills
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public Bills(int id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
