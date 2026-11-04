using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenter.Customer
{
    internal class CustomerModel
    {
        public string name;
        public int price;
        public float discount;
        public int deliveryCharges;

        public CustomerModel(string name, int price, float discount, int deliveryCharges)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
            this.deliveryCharges = deliveryCharges;
        }
    }
}
