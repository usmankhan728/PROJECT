using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.PRODUCT
{
    internal class productRepository
    {
        private readonly string filePath = "products.txt";

        public List<productModel> LoadProducts()
        {
            List<productModel> products = new List<productModel>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string name = line;
                        int price = int.Parse(reader.ReadLine());
                        int warranty = int.Parse(reader.ReadLine());
                        float discount = float.Parse(reader.ReadLine());
                        int delivery = int.Parse(reader.ReadLine());

                        productModel p = new productModel(name, price, warranty, discount, delivery);

                        products.Add(p);
                    }
                }
            }
            else
            {

                products.Add(new productModel("mobile", 50000, 1, 0.1f, 150));
                products.Add(new productModel("watch", 6000, 1, 0.05f, 100));
                products.Add(new productModel("laptop", 150000, 4, 0.2f, 200));
                products.Add(new productModel("Pc", 300000, 5, 0.3f, 300));
                products.Add(new productModel("charger", 800, 6, 0.02f, 50));

                SaveProducts(products);

            }

            return products;
        }

        public void SaveProducts(List<productModel> products)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var p in products)
                {
                    writer.WriteLine(p.Name);
                    writer.WriteLine(p.Price);
                    writer.WriteLine(p.Warranty);
                    writer.WriteLine(p.Discount);
                    writer.WriteLine(p.DeliveryCharges);
                }
            }
        }
    }
}
