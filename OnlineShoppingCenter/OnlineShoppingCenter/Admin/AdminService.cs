using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenter.Admin
{
    internal class AdminService
    {
        private AdminRepository repo = new AdminRepository();

        public List<AdminModel> GetAllProducts()
        {
            List<AdminModel> list = repo.FetchProducts();
            if (list.Count == 0)
            {
                
                list.Add(new AdminModel("mobile", 50000, 1, 0.1, 150));
                list.Add(new AdminModel("watch", 6000, 1, 0.05, 100));
                list.Add(new AdminModel("laptop", 150000, 4, 0.2, 200));
                list.Add(new AdminModel("Pc", 300000, 5, 0.3, 300));
                list.Add(new AdminModel("charger", 800, 6, 0.02, 50));
                repo.SaveProducts(list);

            }
            return list;
        }


        public List<AdminModel> datapages()
        {
            var list = GetAllProducts();

            List<AdminModel> data = new List<AdminModel>();

            for (int i = 0; i < list.Count; i++)
            {
                foreach (var item in list)
                {
                     (data.Count != 3)
                    {
                        data.Add(item);
                    }
                    while(list.Count >= 3 && list.Count < 6)
                    {
                        data.Add(item);
                    }
                }
            }
            return data;
        }

        public void AddItem(string name, double price, double warranty, double discount, double delivery)
        {
            var list = GetAllProducts();
            list.Add(new AdminModel(name, price, warranty, discount, delivery));
            repo.SaveProducts(list);
        }

        public bool RemoveItem(string targetName)
        {
            var list = GetAllProducts();
            bool removed = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == targetName)
                {
                    list.RemoveAt(i);
                    removed = true;
                    break;
                }
            }

            if (removed)
            {
                repo.SaveProducts(list);
            }
            return removed;
        }

        public bool UpdatePrice(string targetName, double newPrice)
        {
            var list = GetAllProducts();
            bool updated = false;

            foreach (var p in list)
            {
                if (p.name == targetName)
                {
                    p.price = newPrice;
                    updated = true;
                }
            }

            if (updated)
            {
                repo.SaveProducts(list);
            }
            return updated;
        }
    }
}
