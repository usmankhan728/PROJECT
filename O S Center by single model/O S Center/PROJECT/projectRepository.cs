using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace O_S_Center.PROJECT
{
    internal class projectRepository
    {
        private readonly string filePath = "products.txt";

        public void save(List<projectModel> products)
        {
            using(StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach(var p in products)
                {
                    sw.WriteLine($"{p.name}\t{p.price}\t{p.discount}\t{p.warranty}\t{p.diliverycharges}");
                }
            }
        }

        public void addItem(projectModel a)
        {
            using(StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{a.name}\t{a.price}\t{a.discount}\t{a.warranty}\t{a.diliverycharges}");
            }
        }

        public List<projectModel> fetch()
        {
            List<projectModel> products = new List<projectModel>();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('\t');
                        if (parts.Length == 5)
                        {
                            string name = parts[0];
                            double price = double.Parse(parts[1]);
                            double discount = double.Parse(parts[2]);
                            double warranty = double.Parse(parts[3]);
                            double deliveryCharges = double.Parse(parts[4]);

                            projectModel p = new projectModel(name, price, discount, warranty, deliveryCharges);
                            products.Add(p);
                        }
                    }
                }
            }
            return products;
        }

        public bool updateprice(string upd,double pri)
        {
            var all = fetch();

            bool isfound = false;
            foreach(var p in all)
            {
                if(p.name == upd)
                {
                    p.price = pri;
                    isfound = true;
                }
            }
            if (isfound)
            {
                save(all);
            }
            return isfound;
        }

        public void deleteItem(string del)
        {
            var all = fetch();
            bool isfound = false;
            for(int i=0; i<all.Count; i++)
            {
                if (all[i].name == del)
                {
                    all.RemoveAt(i);
                    isfound = true;
                }
            }
            if (isfound)
            {
                save(all);
            }
        }
    }
}
