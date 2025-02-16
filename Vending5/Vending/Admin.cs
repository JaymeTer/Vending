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
                new Items(1, "Soda", "A refreshing soft drink", 1.50m),
                new Items(2, "Chips", "A crispy snack", 1.00m),
                new Items(3, "Candy", "A sweet treat", 0.75m),
                new Items(4, "Ice Cream Sandwich", "A frozen vanilla ice cream treat", 2.00m),
                new Items(5, "Beef Jerky", "High-protein dried meat snack", 3.50m),
                new Items(6, "Fresh Cookie", "Soft-baked chocolate chip cookie", 1.25m),
                new Items(7, "Green Tea", "Refreshing unsweetened tea", 1.75m)
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
        public void AddItem(string name, string description, decimal price)
        {
            int newId = items.Count > 0 ? items.Max(i => i.ID) + 1 : 1;
            items.Add(new Items(newId, name, description, price));
            Console.WriteLine($"{name} has been added to the menu.");
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

        private decimal currentBalance = 0m;

        public void InsertMoney(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please insert a positive amount.");
                return;
            }
            currentBalance += amount;
            Console.WriteLine($"Current balance: ${currentBalance:F2}");
        }

        public bool PurchaseItem(int id)
        {
            var item = items.Find(i => i.ID == id);
            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return false;
            }

            if (currentBalance < item.Price)
            {
                Console.WriteLine($"Insufficient funds. You need ${item.Price - currentBalance:F2} more.");
                return false;
            }

            currentBalance -= item.Price;
            Console.WriteLine($"\nDispensing {item.Name}...");
            Console.WriteLine($"Remaining balance: ${currentBalance:F2}");
            return true;
        }

        public decimal ReturnChange()
        {
            decimal change = currentBalance;
            if (change > 0)
            {
                Console.WriteLine($"Returning change: ${change:F2}");
                currentBalance = 0m;
            }
            return change;
        }

        public decimal GetCurrentBalance()
        {
            return currentBalance;
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
                    Console.WriteLine("Enter the price of the item:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        // Create new item and add it
                        AddItem(name, description, price);
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please try again.");
                    }
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
