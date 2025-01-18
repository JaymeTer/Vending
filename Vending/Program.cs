using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the Admin class (manages the vending machine)
            Admin admin = new Admin();
            bool running = true;

            while (running)
            {
                // Display the vending machine menu
                Console.Clear();
                Console.WriteLine("Vending Machine Admin Menu:");
                Console.WriteLine("0. Admin Mode");
                admin.DisplayItems();

                // Ask the user to select an item or go to admin mode
                Console.WriteLine("\nPlease enter the number of your selection:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selection))
                {
                    if (selection == 0)  // Admin mode option
                    {
                        admin.AdminMode();
                    }
                    else if (selection >= 1 && selection <= admin.ItemCount)  // Process key if valid selection
                    {
                        // Vend the item 
                        Items selectedItem = admin.GetItemBySelection(selection);
                        VendItem(selectedItem);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again."); //wrong keystroke
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");//wrong keystroke
                }

                // Ask if the user wants to continue
                Console.WriteLine("\nWould you like to back to the menu?(y/n)"); // Restart loop?
                if (Console.ReadLine().ToLower() != "y")
                {
                    running = false;
                }
            }
        }

        // Function to poop out item.
        public static void VendItem(Items item)
        {
            Console.WriteLine($"Vending: {item.Name} - {item.Description}"); // If you want it to say a new category you added
        }                                                                    // you put it in here such as -{item.Price}")
    }
}