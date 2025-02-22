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
                Console.WriteLine("Vending Machine Admin Menu:");
                Console.WriteLine("0. Admin Mode \n");
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
                        Console.Clear();
                        // Vend the item 
                        Items selectedItem = admin.GetItemBySelection(selection);
                        VendItem(selectedItem);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. Please try again.\n"); //wrong keystroke
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number.\n");//wrong keystroke
                }
            }
        }

        // Function to poop out item.
        public static void VendItem(Items item)
        {
            Console.WriteLine($"Vending: {item.Name}\t-\t{item.Description}\t-\t${item.Price}\n"); // If you want it to say a new category you added
        }                                                                    // you put it in here such as -{item.Price}")
    }
}