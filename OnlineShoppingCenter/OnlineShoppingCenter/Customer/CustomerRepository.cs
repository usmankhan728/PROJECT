using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace OnlineShoppingCenter.Customer
{
    internal class CustomerRepository
    {
        private readonly string filePath = "products.txt";

        public List<CustomerModel> FetchCustomerProducts()
        {
            List<CustomerModel> list = new List<CustomerModel>();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string name = line;
                        int price = int.Parse(sr.ReadLine());
                        sr.ReadLine(); // Skip warranty for customer view
                        float discount = float.Parse(sr.ReadLine());
                        int delivery = int.Parse(sr.ReadLine());

                        list.Add(new CustomerModel(name, price, discount, delivery));
                    }
                }
            }
            return list;
        }
    }
}
