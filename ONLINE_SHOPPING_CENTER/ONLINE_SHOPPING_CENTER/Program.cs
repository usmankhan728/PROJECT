using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ONLINE_SHOPPING_CENTER.AUTHENTICATION;
using ONLINE_SHOPPING_CENTER.BILLING;
using ONLINE_SHOPPING_CENTER.PRODUCT;

namespace ONLINE_SHOPPING_CENTER
{
    class Program
    {
        static void Main(string[] args)
        {
            productService productService = new productService();
            productUI productUI = new productUI();

            authService authService = new authService();
            authUI authUI = new authUI(authService);

            char exit_program = 'u';

            while (exit_program != 'k')
            {
                Console.Clear();
                Console.WriteLine("|**************************************|");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine(" |-----|ONLINE SHOPPING CENTER|-----|");
                Console.WriteLine(" |------------|MANAGEMENT|----------|");
                Console.WriteLine("|--------------------------------------|");
                Console.WriteLine("|**************************************|");
                Console.WriteLine("1...Admin");
                Console.WriteLine("2...Customer");
                Console.WriteLine("3...Exit");
                Console.Write("Enter your choice: ");

                string choiceStr = Console.ReadLine();

                if (choiceStr == "1")
                {
                    if (authUI.Login())
                    {
                        productUI.ShowAdminMenu();
                    }
                }
                else if (choiceStr == "2")
                {
                    billService billService = new billService();
                    billUI billUI = new billUI();
                    billUI.ShowCustomerMenu();
                }
                else if (choiceStr == "3")
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
        }
    }
}
