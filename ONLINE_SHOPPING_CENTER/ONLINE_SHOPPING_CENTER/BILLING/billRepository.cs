using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.BILLING
{
    internal class billRepository
    {
        public void SaveReceipt(string receiptDetails)
        {
            File.AppendAllText("receipts.txt", receiptDetails + "\n");
        }
    }
}
