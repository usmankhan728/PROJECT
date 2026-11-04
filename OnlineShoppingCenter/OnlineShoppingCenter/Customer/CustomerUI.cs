using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineShoppingCenter.Customer
{
    internal class CustomerUI
    {
        private CustomerService service = new CustomerService();

        public void OpenCustomerMenu()
        {
            float total_bill = 0;
            int cust_opt = 0;
            while (cust_opt != 4)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("==========CUSTOMER MENU==========");
                Console.WriteLine("=================================");
                Console.WriteLine("1..View products");
                Console.WriteLine("2..Buy item");
                Console.WriteLine("3.chech two field values :");
                Console.WriteLine("4..Exit");
                Console.WriteLine("=================================\n");
                Console.Write("Enter option: from (1_3) : ");
                cust_opt = int.Parse(Console.ReadLine());

                if (cust_opt == 1)
                {
                    Console.Clear();
                    var list = service.GetProducts();
                    Console.WriteLine("Product\tPrice");
                    foreach (var p in list)
                    {
                        Console.WriteLine(p.name + "\t" + p.price);
                    }
                    Console.ReadKey();
                }
                else if (cust_opt == 2)
                {
                    Console.Clear();
                    Console.Write("Enter product name: ");
                    string buy_name = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    if (service.BuyProduct(buy_name, quantity, ref total_bill))
                    {
                        Console.WriteLine("total bill so far: " + total_bill);
                    }
                    else
                    {
                        Console.WriteLine("product not found");
                    }
                    Console.ReadKey();
                }
                else if(cust_opt == 3)
                {
                    Console.Clear();
                    Console.WriteLine("enter both field name  :");
                    string name = Console.ReadLine();
                    double val = double.Parse(Console.ReadLine());

                    if (service.labtask(name, val))
                    {
                        Console.WriteLine("");
                    }




                }
                else if (cust_opt == 4)
                {
                    Console.Clear();
                    Console.WriteLine("--- BILL ---");
                    Console.WriteLine("Total: " + total_bill);
                    Console.WriteLine("Thanks for shopping");
                    Console.ReadKey();
                }
            }
        }
    }
}
