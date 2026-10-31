using ONLINE_SHOPPING_CENTER.PRODUCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.BILLING
{
    internal class billUI
    {
        private readonly billService _billService;
        private readonly productService _productService;

        public billUI()
        {
            _billService =new billService();
            _productService =new productService();
        }

        public void ShowCustomerMenu()
        {
            int cust_opt = 0;
            while (cust_opt != 3)
            {
                Console.Clear();
                Console.WriteLine("--- CUSTOMER MENU ---");
                Console.WriteLine("1..view products");
                Console.WriteLine("2..buy item");
                Console.WriteLine("3..exit");
                Console.Write("Enter option: ");

                string input = Console.ReadLine();
                cust_opt = int.Parse(input);

                if (cust_opt == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Product\tPrice");
                    foreach (var p in _productService.GetAllProducts())
                    {
                        Console.WriteLine($"{p.Name}\t{p.Price}");
                    }
                    Console.ReadKey();
                }
                else if (cust_opt == 2)
                {
                    Console.Clear();
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter quantity: ");

                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        productModel product = null;

                        List<productModel> allProducts = _productService.GetAllProducts();

                        foreach (productModel p in allProducts)
                        {
                            if (p.Name.ToLower() == name.ToLower())
                            {
                                product = p;
                                break;
                            }
                        }

                        if (product != null)
                        {
                            _billService.ProcessPurchase(product, quantity);
                            Console.WriteLine($"total bill: {_billService.GetTotalBill()}");
                        }
                        else
                        {
                            Console.WriteLine("product not found");
                        }
                    }
                    Console.ReadKey();
                }
                else if (cust_opt == 3)
                {
                    Console.Clear();
                    Console.WriteLine("--- BILL ---");
                    Console.WriteLine($"Total: {_billService.GetTotalBill()}");
                    Console.WriteLine("Thanks for shopping");
                    Console.ReadKey();
                }
            }
        }
    }
}
