using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace OnlineShoppingCenter.Admin
{
    internal class AdminRepository
    {
        private readonly string filePath = "products.txt";

        public List<AdminModel> FetchProducts()
        {
            List<AdminModel> list = new List<AdminModel>();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Split using single tab
                        string[] parts = line.Split('\t');

                        if (parts.Length >= 5)
                        {
                            string name = parts[0];
                            double price = double.Parse(parts[1], CultureInfo.InvariantCulture);
                            double warranty = double.Parse(parts[2], CultureInfo.InvariantCulture);
                            double discount = double.Parse(parts[3], CultureInfo.InvariantCulture);
                            double delivery = double.Parse(parts[4], CultureInfo.InvariantCulture);

                            list.Add(new AdminModel(name, price, warranty, discount, delivery));
                        }
                    }
                }
            }
            return list;
        }

        public void SaveProducts(List<AdminModel> list)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (var p in list)
                {
                    //Use single tabs (\t) uniformly everywhere so splitting works properly
                    sw.WriteLine(p.name + "\t" +
                                 p.price.ToString(CultureInfo.InvariantCulture) + "\t" +
                                 p.warranty.ToString(CultureInfo.InvariantCulture) + "\t" +
                                 p.discount.ToString(CultureInfo.InvariantCulture) + "\t" +
                                 p.deliveryCharges.ToString(CultureInfo.InvariantCulture));
                }
            }
        }
    }
}