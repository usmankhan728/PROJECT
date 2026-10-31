using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.PRODUCT
{
    internal class productModel
    {
        public string Name;
        public int Price;
        public int Warranty;
        public float Discount;
        public int DeliveryCharges;

        public productModel(string name, int price, int warranty, float discount, int deliveryCharges)
        {
            Name = name;
            Price = price;
            Warranty = warranty;
            Discount = discount;
            DeliveryCharges = deliveryCharges;
        }
    }
}
