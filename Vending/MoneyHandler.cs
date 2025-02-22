using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class MoneyHandler
    {
        private List<Bills> _bills;

        public MoneyHandler()
        {
            _bills = new List<Bills>
            {
                new Bills(1, "$1", 1),
                new Bills(2, "$5", 5),
                new Bills(3, "$10", 10),
                new Bills(4, "$20", 20)
            };
        }
        public string Id(int id)
        {
            foreach (var b in _bills)
            {
                if (b.Id == id) { return b.Id.ToString(); }
            }
            return null;
        }
        public string Bill(int id)
        {
            foreach (var b in _bills)
            {
                if (b.Id == id) { return b.Name; }
            }
            return null;
        }
        public int Value(int id)
        {
            foreach (var b in _bills)
            {
                if (b.Id == id) { return b.Value; }
            }
            return 0;
        }
    }
}
