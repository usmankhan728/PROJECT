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

        public int _currentIndex = 0; 

        public List<AdminModel> GetNextTwoRecords()
        {
            var allProducts = GetAllProducts();
            List<AdminModel> twoRecords = new List<AdminModel>();

            if (_currentIndex >= allProducts.Count)
            {
                _currentIndex = 0;
                return twoRecords;
            }
            int count = 0;
            for (int i = _currentIndex; i < allProducts.Count && count < 2; i++)
            {
                twoRecords.Add(allProducts[i]);
                count++;
            }
            _currentIndex += 2;

            return twoRecords;
        }

        public void ResetPagination()
        {
            _currentIndex = 0;
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
