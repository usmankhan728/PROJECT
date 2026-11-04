using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenter.Admin
{
    internal class AdminModel
    {
        public string name;
        public double price;
        public double warranty;
        public double discount;
        public double deliveryCharges;

        public AdminModel(string name, double price, double warranty, double discount, double deliveryCharges)
        {
            this.name = name;
            this.price = price;
            this.warranty = warranty;
            this.discount = discount;
            this.deliveryCharges = deliveryCharges;
        }
    }
}
