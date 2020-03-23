using System;using System.Collections.Generic;


namespace SalesApp
{
    public interface IDBHandler
    {
        Product GetProductRecord(string productCode);
        Product SetPrice(string productCode, double price);
        Product SetBulkPrice(string productCode, int bulkItems, double price);
    }
}
