using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.PRODUCT
{
    internal class productUI
    {
        private readonly productService _productService = new productService();

        public void ShowAdminMenu()
        {
            int admin_opt = 0;
            while (admin_opt != 5)
            {
                Console.Clear();
                Console.WriteLine("--- ADMIN MENU ---");
                Console.WriteLine("1..add item");
                Console.WriteLine("2..remove item");
                Console.WriteLine("3..view products");
                Console.WriteLine("4..change price");
                Console.WriteLine("5..logout");
                Console.Write("Enter option: ");

                string input = Console.ReadLine();
                admin_opt = int.Parse(input);

                if (admin_opt == 1)
                {
                    Console.Clear();
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter price: ");
                    int price = int.Parse(Console.ReadLine());
                    Console.Write("Enter warranty: ");
                    int warranty = int.Parse(Console.ReadLine());
                    Console.Write("Enter discount: ");
                    float discount = float.Parse(Console.ReadLine());
                    Console.Write("Enter delivery charges: ");
                    int delivery = int.Parse(Console.ReadLine());

                    _productService.AddProduct(name, price, warranty, discount, delivery);
                    Console.WriteLine("item added");
                    Console.ReadKey();
                }
                else if (admin_opt == 2)
                {
                    Console.Clear();
                    Console.Write("Enter item name to remove: ");
                    string name = Console.ReadLine();
                    if (_productService.RemoveProduct(name))
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
                    Console.WriteLine("Product\tPrice\tWarranty\tDiscount\tDelivery");
                    foreach (var p in _productService.GetAllProducts())
                    {
                        Console.WriteLine($"{p.Name}\t{p.Price}\t{p.Warranty}\t\t{p.Discount}\t\t{p.DeliveryCharges}");
                    }
                    Console.ReadKey();
                }
                else if (admin_opt == 4)
                {
                    Console.Clear();
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter new price: ");
                    int newPrice = int.Parse(Console.ReadLine());

                    if (_productService.UpdatePrice(name, newPrice))
                    {
                        Console.WriteLine("price updated");
                    }
                    else
                    {
                        Console.WriteLine("product not found");
                    }
                    Console.ReadKey();
                }
                else if (admin_opt == 5)
                {
                    Console.WriteLine("logging out...");
                    Console.ReadKey();
                }
            }
        }
    }
}
