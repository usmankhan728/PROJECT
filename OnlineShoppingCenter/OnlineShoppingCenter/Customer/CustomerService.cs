using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenter.Customer
{
    internal class CustomerService
    {
        private CustomerRepository repo = new CustomerRepository();

        public List<CustomerModel> GetProducts()
        {
            return repo.FetchCustomerProducts();
        }

        public bool labtask(string name,double val)
        {
            var list = GetProducts();

            bool check = false;
            foreach(var item in list)
            {
                if(name == item.name && val == item.price)
                {
                    check = true;
                }
            }
            return check;
        }

        public bool BuyProduct(string buyName, int quantity, ref float total_bill)
        {
            var list = GetProducts();
            foreach (var p in list)
            {
                if (p.name == buyName)
                {
                    float item_price = p.price - (p.price * p.discount);
                    total_bill = total_bill + (item_price * quantity) + p.deliveryCharges;
                    return true;
                }
            }
            return false;
        }
    }
}
