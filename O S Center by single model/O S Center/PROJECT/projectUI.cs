using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace O_S_Center.PROJECT
{
    internal class projectUI
    {
        public projectService service = new projectService();

        List<projectModel> products = new List<projectModel>();

        public void start()
        {
            products.Add(new projectModel("mobile", 50000, 0.1, 1, 150));
            products.Add(new projectModel("watch", 6000,0.5, 5, 100));
            products.Add(new projectModel("laptop", 150000, 0.2, 2, 200));
            products.Add(new projectModel("Pc", 300000,0.3, 3, 300));
            products.Add(new projectModel("charger", 800, 0.1, 2, 50));
            service.product(products);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================================================");
                Console.WriteLine("============ONLINE SHOPPING CENTER MANAGMENT SYSTEM============");
                Console.WriteLine("===============================================================\n");
                Console.WriteLine("1.ADDMIN :");
                Console.WriteLine("2.CUSTOMER :");
                Console.WriteLine("3.EXIT :");
                Console.WriteLine("===============================================================");
                Console.WriteLine("Enter ur option :");
                int option = int.Parse(Console.ReadLine());

                
                if (option == 1)
                {
                    Console.Clear();
                    // admin menu;
                    for(int i=0; i<3; i++)
                    {
                        Console.Write("ENTER UR NAME : " );
                        string NAME = Console.ReadLine();
                        Console.Write("ENTER UR PASSWORD :");
                        int password = int.Parse(Console.ReadLine());

                        if (NAME == "astro" && password == 123)
                        {
                            bool inAdminMenu = true;

                            while (inAdminMenu)
                            {
                                Console.Clear();
                                Console.WriteLine("========================================");
                                Console.WriteLine("              ADMIN MENU                ");
                                Console.WriteLine("========================================");
                                Console.WriteLine("1. Add New Item");
                                Console.WriteLine("2. View All Items");
                                Console.WriteLine("3. Update Item Price");
                                Console.WriteLine("4. Delete Item");
                                Console.WriteLine("5. Exit to Main Menu");
                                Console.WriteLine("========================================");
                                Console.Write("Enter your choice (1-5): ");

                                int choice = int.Parse(Console.ReadLine());
                                if (choice == 1)
                                {
                                    Console.Clear();
                                    Console.Write("Enter product name :");
                                    string name = Console.ReadLine();
                                    Console.Write("Enter product price :");
                                    double price = double.Parse(Console.ReadLine());
                                    Console.Write("Enter product discount :");
                                    double discount = double.Parse(Console.ReadLine());
                                    Console.Write("Enter product waranty :");
                                    double waranty = double.Parse(Console.ReadLine());
                                    Console.Write("Enter product dilivaryCharger :");
                                    double dilivaryCharges = double.Parse(Console.ReadLine());

                                    projectModel a = new projectModel(name, price, discount, waranty, dilivaryCharges);

                                    service.addnewproduct(a);

                                    Console.WriteLine("ITEM ADDED SUCCESSFULLY ...");
                                    Console.ReadKey();
                                }
                                else if (choice == 2)
                                {
                                    Console.Clear();
                                    var result = service.data();
                                    foreach(var p in result)
                                    {
                                        Console.WriteLine($"{p.name}\t{p.price}\t{p.discount}\t{p.warranty}\t{p.diliverycharges}");
                                    }
                                    Console.ReadKey();
                                }
                                else if (choice == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter item name to update price :");
                                    string upd = Console.ReadLine();
                                    Console.WriteLine("Enter new price :");
                                    double pri = Double.Parse(Console.ReadLine());
                                    
                                    if(service.priceChange(upd, pri))
                                    {
                                        Console.WriteLine("PRICE UPDATED...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("PRODUCT NOT FOUND ...");
                                    }
                                    Console.ReadKey();
                                }
                                else if (choice == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("ENTER PRODUCT NAME TO REMOVE FROM STORE :");
                                    string del = Console.ReadLine();

                                    service.delete(del);

                                    Console.WriteLine("ITEM REMOVED FROM THE STORE :");
                                    Console.ReadKey();

                                }
                                else if (choice == 5)
                                {
                                    Console.WriteLine("\nExiting Admin Menu...");
                                    inAdminMenu = false;
                                    Console.ReadKey();
                                }
                            }
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            if (i < 3)
                            {
                                Console.WriteLine("WRONG NAME OR PASSWORD...Try again !");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("TOO MANY WRONG ATTEMPT !");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }

                }
                else if (option == 2)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("========================================");
                        Console.WriteLine("              CUSTOMER MENU             ");
                        Console.WriteLine("========================================");
                        Console.WriteLine("1. View All Products");
                        Console.WriteLine("2. Buy Product (Checkout)");
                        Console.WriteLine("3. Exit to Main Menu");
                        Console.WriteLine("========================================");
                        Console.Write("Enter your choice (1-3): ");

                        int choice = int.Parse(Console.ReadLine());

                        if(choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("========================================");
                            Console.WriteLine("             AVAILABLE ITEMS            ");
                            Console.WriteLine("========================================");

                            var result = service.data();
                            if (result.Count == 0)
                            {
                                Console.WriteLine("No items available right now.");
                            }
                            else
                            {
                                Console.WriteLine("Name\tPrice\tDiscount\tWarranty\tDelivery");
                                Console.WriteLine("------------------------------------------------");
                                foreach (var p in result)
                                {
                                    Console.WriteLine($"{p.name}\t{p.price}\t{p.discount}\t\t{p.warranty}\t\t{p.diliverycharges}");
                                }
                            }
                            Console.ReadKey();
                        }
                        else if(choice == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("========================================");
                            Console.WriteLine("              BUY PRODUCT               ");
                            Console.WriteLine("========================================");

                            var result = service.data();
                            if (result.Count == 0)
                            {
                                Console.WriteLine("Sorry, no products are available to buy.");
                            }
                            else
                            {
                                Console.WriteLine("Items in Store:");
                                foreach (var p in result)
                                {
                                    Console.WriteLine($"- {p.name} (Price: {p.price})");
                                }

                                Console.Write("\nEnter the name of the product you want to buy: ");
                                string buyName = Console.ReadLine();

                                projectModel selectedProduct = null;
                                foreach (var p in result)
                                {
                                    if (p.name == buyName)
                                    {
                                        selectedProduct = p;
                                        break;
                                    }
                                }

                                if (selectedProduct != null)
                                {
                                    double discountAmount = selectedProduct.price * selectedProduct.discount;
                                    double finalTotal = (selectedProduct.price - discountAmount) + selectedProduct.diliverycharges;

                                    Console.Clear();
                                    Console.WriteLine("========================================");
                                    Console.WriteLine("              BILL SUMMARY              ");
                                    Console.WriteLine("========================================");
                                    Console.WriteLine($"Product Name     : {selectedProduct.name}");
                                    Console.WriteLine($"Original Price   : {selectedProduct.price}");
                                    Console.WriteLine($"Discount Applied : {discountAmount}");
                                    Console.WriteLine($"Delivery Charges : {selectedProduct.diliverycharges}");
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine($"Total Bill Amount: {finalTotal}");
                                    Console.WriteLine("========================================");
                                    Console.WriteLine("PURCHASE SUCCESSFUL! Thank you for shopping.");
                                }
                                else
                                {
                                    Console.WriteLine("\nProduct not found in the store!");
                                }
                            }
                            Console.ReadKey();

                        }
                        else if(choice == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("\nRETURNING TO MAIN Menu...");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else if (option == 3)
                {
                    break;
                }
            }
        }
    }
}
