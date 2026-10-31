using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_S_Center.PROJECT
{
    internal class projectModel
    {
        public string name;
        public double price;
        public double discount;
        public double warranty;
        public double diliverycharges;


        public projectModel()
        {
            this.name = "";
            this.price = 0.0;
            this.discount = 0.0;
            this.warranty = 0.0;
            this.diliverycharges = 0.0;
        }

        
        public projectModel(string name, double price, double discount,double warranty, double deliveryCharges)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
            this.warranty = warranty;
            this.diliverycharges = deliveryCharges;
        }

    }
}
