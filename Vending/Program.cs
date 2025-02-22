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
            int balance = 0;

            Menu(ref balance, admin);
        }
        public static void Menu(ref int balance, Admin admin)
        {
            do
            {
                // Display the vending machine menu
                Console.WriteLine($"Balance: ${balance}\n");
                Console.WriteLine("Vending Machine Admin Menu:");
                Console.WriteLine("0. Admin Mode");
                Console.WriteLine("1. Insert cash");
                Console.WriteLine("2. Done\n");

                // Ask the user to select an item or go to admin mode
                Console.WriteLine("\nPlease enter the number of your selection:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selection))
                {
                    if (selection == 0)  // Admin mode option
                    {
                        admin.AdminMode();
                    }
                    else if (selection == 1)
                    {
                        Console.Clear();
                        AcceptPayment(ref balance, admin);
                    }
                    else if (selection == 2)
                    {
                        Console.Clear();
                        if (balance > 0)
                        {
                            Console.WriteLine($"Here is your change: ${balance}");
                        }
                        Console.WriteLine("Thank you! Please come again!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter a valid number.\n");//wrong keystroke
                    }
                }
            } while (true);
        }
        public static void MakeSelection(ref int balance, Admin admin)
        {
            Console.WriteLine($"Balance: ${balance}\n");
            Console.WriteLine("0. Menu\n");
            admin.DisplayItems();
            Console.WriteLine("\nPlease enter the number of your selection:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selection))
            {
                if (selection == 0)
                {
                    Console.Clear();
                    Menu(ref balance, admin);
                }
                else if (selection >= 1 && selection <= admin.ItemCount)  // Process key if valid selection
                {
                    Console.Clear();
                    // Vend the item 
                    Items selectedItem = admin.GetItemBySelection(selection);
                    if (selectedItem.Price <= balance)
                    {
                        VendItem(selectedItem);
                        balance -= selectedItem.Price;
                        MakeSelection(ref balance, admin);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Balanace");
                        AcceptPayment(ref balance, admin);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid selection. Please try again.\n"); //wrong keystroke
                    MakeSelection(ref balance, admin);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid number.\n");//wrong keystroke
                MakeSelection(ref balance, admin);
            }
        }
        // Function to poop out item.
        public static void VendItem(Items item)
        {
            Console.WriteLine($"Vending: {item.Name}\t-\t{item.Description}\t-\t${item.Price}\n"); // If you want it to say a new category you added
                                                                                                   // you put it in here such as -{item.Price}")
        }
        public static void AcceptPayment(ref int balance, Admin admin)
        {
            MoneyHandler moneyHandler = new MoneyHandler();
            do
            {
                Console.WriteLine($"Balance: ${balance}\n" +
                    $"Enter payment\n" +
                    "0. Proceed to selection\n" +
                    $"{moneyHandler.Id(1)}. {moneyHandler.Bill(1)}\n" +
                    $"{moneyHandler.Id(2)}. {moneyHandler.Bill(2)}\n" +
                    $"{moneyHandler.Id(3)}. {moneyHandler.Bill(3)}\n" +
                    $"{moneyHandler.Id(4)}. {moneyHandler.Bill(4)}");
                string input = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(input, out int selection))
                {
                    if (selection == 0)
                    {
                        Console.Clear();
                        MakeSelection(ref balance, admin);
                    }
                    else
                    {
                        balance += moneyHandler.Value(selection);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }
    }
}