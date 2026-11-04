using OnlineShoppingCenter.Admin;
using OnlineShoppingCenter.Customer;
using System;

namespace OnlineShoppingCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdminUI adminUI = new AdminUI();
            CustomerUI customerUI = new CustomerUI();

            char exit_program = 'u';

            while (exit_program != 'k')
            {
                Console.Clear();
                Console.WriteLine("|**************************************|");
                Console.WriteLine("|======================================|");
                Console.WriteLine("       ------------------------      ");
                Console.WriteLine("       |ONLINE SHOPPING CENTER|     ");
                Console.WriteLine("              |MANAGEMENT|          ");
                Console.WriteLine("              ------------      ");
                Console.WriteLine("|======================================|");
                Console.WriteLine("|**************************************|\n");
                Console.WriteLine("(1)...Admin");
                Console.WriteLine("(2)...Customer");
                Console.WriteLine("(3)...Exit");
                Console.WriteLine("\n========================================");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("u selected : " + choice);

                if (choice == 1)
                {
                    if (adminUI.AdminLogin())
                    {
                        adminUI.OpenAdminMenu();
                    }
                }
                else if (choice == 2)
                {
                    customerUI.OpenCustomerMenu();
                }
                else if (choice == 3)
                {
                    exit_program = 'k';
                }
                else
                {
                    Console.WriteLine("wrong option");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("thank u for using this program");
            Console.ReadKey();
        }
    }
}

