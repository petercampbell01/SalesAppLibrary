/* Controller Class is used to receive input from the Scanner, and coordinate
 * product lookup through the DBHandler, send item to Cart and then output 
 * purchase information to the View.
 * 22/03/2020
 * Peter Campbell
 */
using System;

namespace SalesApp
{
    public class Controller : IDataReceiver
    {
        private Scanner Scan;
        private View Output;
        private Cart MyCart;
        private DBHandler MyDB;

        public Controller(Scanner scan, View output)
        {
            Scan = scan;
            Output = output;
            MyCart = new Cart();
            MyDB = new DBHandler();
            //Tell scan where to send data.
            Scan.AddDataReceiver(this);
        }

        public void ScanProduct(string code)
        {
            //scan product.
            Scan.ScanProduct(code);
        }

        public Boolean ReceiveScanData(string scanIn)
        {
            //do DB lookup.
            Product item = MyDB.GetProductRecord(scanIn);
            // add item to cart.
            MyCart.AddItem(item);
            //send MyCart data to view.
            Output.ShowCartStatus(MyCart);
            return true;
        }

        public Product SetPrice(string productCode, double price)
        {
            return MyDB.SetPrice(productCode, price);
        }
        public Product SetBulkPrice(string productCode, int bulkItems, double price)
        {
            return MyDB.SetBulkPrice(productCode, bulkItems, price);
        }

        public double CalculateTotal()
        {
            return MyCart.CalculateTotalPrice();
        }

        public void EmptyCart()
        {
            MyCart.EmptyCart();
        }
    }
}
