/** This class handles the connection to the database and executes
*   database queries. 
*   In this case it will return test data to demonstrate data flow.
*   The Handler would receive a request make the right query for the DB and then
*   instantiate a Product object which is then returned to the controller.
*   As this class is currently written to deal with fake data this functionality has not been
*   created. The class generates fake data, and when a search query is made returns the desired product.
*   22/03/2020
*   Peter Campbell
*/

using System.Collections.Generic;

namespace SalesApp
{

    public class DBHandler : IDBHandler
    {

        private List<Product> ProductData;

        // Set ProductData
        public DBHandler()
        {
            ProductData = new List<Product>() {
                new Product(){ ProductCode = "A", UnitPrice = 1.25, BulkNumber = 3, BulkPrice = 3, NumberOfItems = 0, TotalPrice = 0 },
                new Product(){ ProductCode = "B", UnitPrice = 4.25, NumberOfItems = 0, TotalPrice = 0 },
                new Product(){ ProductCode = "C", UnitPrice = 1, BulkNumber = 6, BulkPrice = 5, NumberOfItems = 0, TotalPrice = 0 },
                new Product(){ ProductCode = "D", UnitPrice = 0.75, NumberOfItems = 0, TotalPrice = 0 }
            };
        }

        public Product GetProductRecord(string productCode)
        {
            return ProductData.Find(x => x.ProductCode.Equals(productCode));
        }

        public Product SetPrice(string productCode, double price)
        {
            Product myProduct = GetProductRecord(productCode);
            myProduct.UnitPrice = price;
            return myProduct;
        }

        public Product SetBulkPrice(string productCode, int bulkItems, double price)
        {
            Product myProduct = GetProductRecord(productCode);
            myProduct.BulkNumber = bulkItems;
            myProduct.BulkPrice = price;
            return myProduct;
        }
    }
}
