using ONLINE_SHOPPING_CENTER.PRODUCT;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.BILLING
{
    internal class billService
    {
        private readonly billModel _bill;
        private readonly billRepository _repository;

        public billService()
        {
            _bill = new billModel();
            _repository = new billRepository();
        }

        public float GetTotalBill()
        {
            return _bill.TotalBill;
        }

        public bool ProcessPurchase(productModel product, int quantity)
        {
            if (product == null)
            {
                return false;
            }
            else
            {
                //Calculate discounted item price
                float itemPrice = product.Price - (product.Price * product.Discount);

                //Add total cost for this purchase to the bill
                _bill.TotalBill = _bill.TotalBill + (itemPrice * quantity) + product.DeliveryCharges;

                //Prepare receipt line using traditional string concatenation (+)
                string receiptDetails = "Bought " + quantity + " x " + product.Name + ", Total so far: " + _bill.TotalBill;

                //Save directly to file (or call repo if keeping repo)
                File.AppendAllText("receipts.txt", receiptDetails + "\n");

                return true;
            }
        }
    }
}
