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
        public int Price { get; set; }   //<-----example of adding a category "Price"

        // Constructor
        public Items(int id, string name, string description, int price)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;       //< -----example of adding a category "Price"
        }
        // This streamlines the output otherwise we need to specify line by line in main how we want each item to display
        public override string ToString()
        {
            return $"{ID}.\t{Name}\t-\t{Description}\t-\t${Price}";   //<-----example of adding a category "Price"
        }
    }
}
