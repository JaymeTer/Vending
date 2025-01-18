using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Items // This class stores the ID, Name, and description of the Items nothing else is handled here.
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Add new catagory EXAMPLE is in each section.
        // public int Price { get; set; }

        // Constructor for items
        public Items(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        //  Price = price;
        }
        // This streamlines the output otherwise we need to specify line by line in main how we want each item to display
        public override string ToString()
        {
            return $"{ID}. {Name} - {Description}";// the $ makes printing the list easier dont remove it.
         // return ${ID}. {Name} - {Description} - $ {Price}";
        }
    }
}
