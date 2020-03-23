/* Library class to store information about single product
*  at point of sale.
*  Class includes all relevant details for sale including number of items
*  bulk discounts and calculates pricing based on unit and bulk prices.
*  Add and remove methods are used to changed number of items and return
*  updated TotalPrice.
*  22/03/2020
*  Peter Campbell
*/
using System;

namespace SalesAppLibrary
{
    public class Product
    {
        public string ProductCode { get; set; }
        public double UnitPrice { get; set; }
        public int? BulkNumber { get; set; }
        public double? BulkPrice { get; set; }
        public int NumberOfItems { get; set; }
        public double TotalPrice { set; get; }

        public double AddItem()
        {
            NumberOfItems++;
            return UpdatePrice();
        }

        public double RemoveItem()
        {
            NumberOfItems--;
            return UpdatePrice();
        }

        private double UpdatePrice()
        {
            // Set local variables to replace nullable values to enable math calculations.
            // Decimal used to enable use of Math.Floor().
            decimal UnitPurchases = NumberOfItems;
            decimal bulkPurchases = 0;
            decimal bulkDivisor = BulkNumber == null ? 0 : (decimal)BulkNumber;
            double bulkCost = BulkPrice == null ? 0 : (double)BulkPrice;

            // Set number of bulk purchases and individual unit purchases.
            if (BulkNumber != null && BulkPrice != null)
            {
                bulkPurchases = Math.Floor((NumberOfItems / bulkDivisor));
                UnitPurchases = (NumberOfItems % bulkDivisor);
            }

            // Calculate TotalPrice, set TotalPrice and return it.
            TotalPrice = ((double)bulkPurchases * bulkCost) + ((double)UnitPurchases * UnitPrice);
            return TotalPrice;
        }

        public string ToString()
        {
            return String.Format("Product Code: {0} Unit Price: {1} No. {2} Total Price: {3}\n",
                                   ProductCode, UnitPrice, NumberOfItems, TotalPrice);
        }
    }
}
