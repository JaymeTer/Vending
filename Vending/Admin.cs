using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Admin // This class handles the add and removal of items as well as displaying the items.
    {
        private List<Items> items; // these are the items


        public Admin()
        {
            items = new List<Items> // starting item list 
            {
                new Items(1, "Soda", "A refreshing soft drink"), // any added catagories such as price initial values must be here
                new Items(2, "Chips", "A crispy snack"),
                new Items(3, "Candy", "A sweet treat")
            };
        }

        // Function to display items
        public void DisplayItems()
        {
            Console.WriteLine("Vending Machine Customer Menu:");
            foreach (var item in items) // assigns variables for items item list
            {
                Console.WriteLine(item); // poofs out the items from the Items list
            }
        }

        // Function to add a new item
        public void AddItem(Items newItem)
        {
            items.Add(newItem);
            Console.WriteLine($"{newItem.Name} has been added to the menu.");
        }

        // Function to remove an item from menu by ID
        public void RemoveItem(int id)
        {
            var itemToRemove = items.Find(item => item.ID == id); // checks that the ID is a actual item.
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.Name} has been removed from the menu.");
            }
            else
            {
                Console.WriteLine("Item not found."); // if they choose a invalid ID
            }
        }

        // List count
        public int ItemCount => items.Count;

        // Function to get an item by selection
        public Items GetItemBySelection(int selection)
        {
            return items[selection - 1];
        }

        // Admin mode menu and options
        public void AdminMode()
        {
            bool adminRunning = true;
            while (adminRunning)
            {
                Console.Clear();
                Console.WriteLine("Admin Mode:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");               // Admin menu
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Please select an option: ");
                string adminInput = Console.ReadLine();

                if (adminInput == "1")  // Add item remmember if you add a item catagory you must get the input here
                {
                    Console.WriteLine("Enter the name of the item:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the description of the item:");
                    string description = Console.ReadLine();
                    //Console.Writeline("Enter the price of the item:");  <-----example of adding a catagory "Price" to Items
                    //int price = Console.ReadLine();


                    // Create new item and add it
                    int newId = ItemCount + 1; // Adds item to ID list by adding +1
                    Items newItem = new Items(newId, name, description); // Fills info
                    AddItem(newItem);
                }
                else if (adminInput == "2")  // Remove item 
                {
                    Console.WriteLine("Enter the ID of the item you want to remove:");
                    if (int.TryParse(Console.ReadLine(), out int id)) // if valid ID is chosen removes item.
                    {
                        RemoveItem(id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid ID."); //wrong keystroke
                    }
                }
                else if (adminInput == "3")  // Back to main menu
                {
                    adminRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again."); //wrong keystroke
                }
            }
        }
    }
}