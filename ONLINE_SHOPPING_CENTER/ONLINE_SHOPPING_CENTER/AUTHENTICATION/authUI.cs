using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.AUTHENTICATION
{
    internal class authUI
    {
        public authService _authService = new authService();

        public bool Login()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.WriteLine($"Login Attempt {i + 1}");

                Console.Write("Enter admin name: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                int password = int.Parse(Console.ReadLine());

                if (_authService.CheckAdminConditions(username, password))
                {
                    Console.WriteLine("Login successful....!");
                    Console.ReadKey();
                    return true;
                }

                Console.WriteLine("Wrong name or password");
                Console.ReadKey();
            }
            return false;
        }
    }
}
