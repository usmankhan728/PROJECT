using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineShoppingCenter.Admin
{
    internal class AdminUI
    {
        private AdminService service = new AdminService();

        public bool AdminLogin()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.WriteLine("login attempt " + (i + 1));
                Console.Write("Enter admin name: ");
                string name = Console.ReadLine();
                Console.Write("Enter password: ");
                int password = int.Parse(Console.ReadLine());

                if (name == "usman" && password == 661)
                {
                    Console.WriteLine("login successfully....!");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("wrong name or password");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("too many wrong attempts...........!");
            Console.ReadKey();
            return false;
        }

        public void OpenAdminMenu()
        {
            int admin_opt = 0;
            while (admin_opt != 6)
            {
                Console.Clear();
                Console.WriteLine("|==============================|");
                Console.WriteLine("|==========ADMIN MENU==========|");
                Console.WriteLine("|==============================|");
                Console.WriteLine("|1..Add item                   |");
                Console.WriteLine("|2..Remove item                |");
                Console.WriteLine("|3..View products              |");
                Console.WriteLine("|4..Change price               |");
                Console.WriteLine("|5.view records in pages :");
                Console.WriteLine("|6..Logout                     |");
                Console.WriteLine("|==============================|\n");
                Console.Write("Enter option: from (1_5) : ");
                admin_opt = int.Parse(Console.ReadLine());

                if (admin_opt == 1)
                {
                    Console.Clear();
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Enter warranty: ");
                    double warranty = double.Parse(Console.ReadLine());
                    Console.Write("Enter discount: ");
                    double discount = double.Parse(Console.ReadLine());
                    Console.Write("Enter delivery charges: ");
                    double delivery = double.Parse(Console.ReadLine());

                    service.AddItem(name, price, warranty, discount, delivery);
                    Console.WriteLine("item added");
                    Console.ReadKey();
                }
                else if (admin_opt == 2)
                {
                    Console.Clear();
                    Console.Write("Enter item name to remove: ");
                    string del = Console.ReadLine();

                    if (service.RemoveItem(del))
                    {
                        Console.WriteLine("item removed");
                    }
                    else
                    {
                        Console.WriteLine("product not found");
                    }
                    Console.ReadKey();
                }
                else if (admin_opt == 3)
                {
                    Console.Clear();
                    var list = service.GetAllProducts();
                    Console.WriteLine("Product\tPrice\tWarranty\tDiscount\tDelivery");
                    foreach (var p in list)
                    {
                        Console.WriteLine(p.name + "\t" + p.price + "\t" + p.warranty + "\t\t" + p.discount + "\t\t" + p.deliveryCharges);
                    }
                    Console.ReadKey();
                }
                else if (admin_opt == 4)
                {
                    Console.Clear();
                    Console.Write("Enter product name: ");
                    string target = Console.ReadLine();
                    Console.Write("Enter new price: ");
                    double newPrice = double.Parse(Console.ReadLine());

                    if (service.UpdatePrice(target, newPrice))
                    {
                        Console.WriteLine("price updated");
                    }
                    else
                    {
                        Console.WriteLine("product not found");
                    }
                    Console.ReadKey();
                }
                else if(admin_opt == 5)
                {
                    service.ResetPagination();
                    Console.Clear();
                    List<AdminModel> records = service.GetNextTwoRecords();

                    if (records.Count == 0)
                    {
                        Console.ReadKey();
                        break;
                    }

                    for (int i = 0; i < records.Count; i++)
                    {
                        var item = records[i];
                        Console.WriteLine($"ID   : {item.name}");
                        Console.WriteLine($"Name : {item.price}");
                        Console.WriteLine($"Price: {item.warranty}");
                       
                    }

                    Console.WriteLine("\nPress ANY key to view the next records...");
                    Console.ReadKey();
                }

                else if (admin_opt == 6)
                {
                    Console.WriteLine("logging out...");
                    Console.ReadKey();
                }
            }
        }
    }
}
