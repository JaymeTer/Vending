using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Items // This class stores the ID, Name, and description of the Items nothing else is handled here. This is
                       // where you would add new catagories. Each line has a example of adding a "Price" Category for reference
                       // You also must update the admin.cs if you create a new catagory. Those examples are there as well.
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Constructor
        public Items(int id, string name, string description, decimal price)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
        }
        // This streamlines the output otherwise we need to specify line by line in main how we want each item to display
        public override string ToString()
        {
            return $"{ID}. {Name} - {Description} - ${Price:F2}";
        }
    }
}
