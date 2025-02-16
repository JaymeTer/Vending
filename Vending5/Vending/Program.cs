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
                Console.WriteLine("Vending Machine Menu:");
                Console.WriteLine("0. Admin Mode");
                Console.WriteLine("1. Insert Money");
                Console.WriteLine("2. Return Change");
                Console.WriteLine("\nAvailable Items:");
                admin.DisplayItems();
                Console.WriteLine($"\nCurrent Balance: ${admin.GetCurrentBalance():F2}");

                Console.WriteLine("\nPlease enter your selection:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selection))
                {
                    if (selection == 0)  // Admin mode option
                    {
                        admin.AdminMode();
                    }
                    else if (selection == 1) // Insert money
                    {
                        Console.WriteLine("Enter amount to insert (e.g., 1.00):");
                        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                        {
                            admin.InsertMoney(amount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please enter a valid number.");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else if (selection == 2) // Return change
                    {
                        admin.ReturnChange();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else if (selection >= 3 && selection <= admin.ItemCount + 2)  // Process item selection
                    {
                        // Adjust selection to match item ID (subtract 2 because of admin and insert money options)
                        if (admin.PurchaseItem(selection - 2))
                        {
                            Console.WriteLine("Thank you for your purchase!");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
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