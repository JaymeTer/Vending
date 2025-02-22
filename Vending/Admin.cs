using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                new Items(1, "Soda", "A refreshing soft drink", 2), // any added categories such as price's initial values must be added here
                new Items(2, "Chips", "A crispy snack\t", 3),
                new Items(3, "Candy", "A sweet treat\t", 1)
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

        // Function to remove an item from menu by ID and reassign IDs
        public void RemoveItem(int id)
        {
            var itemToRemove = items.Find(item => item.ID == id); // Checks if the ID is valid
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove); // Remove the item from the list

                // Reassign IDs to the remaining items to ensure they are in order and not missing numbers
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].ID = i + 1; // Start at 1 and increase ID by +1
                }
                Console.WriteLine($"{itemToRemove.Name} has been removed from the menu.");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Item not found."); // If the ID doesn't exist
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
                Console.WriteLine("2. Remove Item");               // admin menu
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Please select an option: ");
                string adminInput = Console.ReadLine();

                if (adminInput == "1")  // add item remmember if you add a item category you must add it here like the example.
                {
                    Console.WriteLine("Enter the name of the item:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the description of the item:");
                    string description = Console.ReadLine();
                    Console.WriteLine("Enter the price of the item:");  //< -----example of adding a category "Price" to Items
                    int price = int.Parse(Console.ReadLine());


                    // Create new item and add it
                    int newId = ItemCount + 1; // adds item to ID list by adding +1 
                    Items newItem = new Items(newId, name, description, price); // , price); <-----example of adding a category "Price" to Items
                    AddItem(newItem);
                }
                else if (adminInput == "2")  // remove item 
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
                else if (adminInput == "3")  // back to main menu
                {
                    Console.Clear();
                    adminRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again."); // wrong keystroke
                }

                // Asks which menu they want to goto after add/remove
                if (adminInput == "1" || adminInput == "2")
                {
                    Console.WriteLine("Do you want to return to Admin Mode or go to the Main Menu?");
                    Console.WriteLine("Enter '1' to return to Admin Mode or '2' to go to the Main Menu.");
                    string choice = Console.ReadLine();
                    if (choice == "2")
                    {
                        adminRunning = false; // exit Admin Mode 
                    }
                }
            }
        }
    }
}
