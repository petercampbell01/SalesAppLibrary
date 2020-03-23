/** Class takes cart and converts it to formatted text for user.
 * 22/03/2020
 * Peter Campbell
 */
using System;

namespace SalesApp
{
    public interface IView
    {
        void ShowCartStatus(Cart myCart);
    }


    public class View : IView
    {
        public void ShowCartStatus(Cart myCart)
        {
            string bulkPhrase;
            string statusReport = "My Shopping Cart\n";

            //Loop through List and generate status report;
            foreach (Product item in myCart.GetCart())
            {
                if (item.BulkNumber == null)
                {
                    bulkPhrase = "";
                }
                else
                {
                    bulkPhrase = String.Format("{0} for {1}", item.BulkNumber, item.BulkPrice);
                }
                statusReport = String.Concat(statusReport, item.ToString());
            }
            string summary = String.Format("Total Cost: \t\t{0}\n****\n", myCart.TotalPurchasePrice);
            statusReport = String.Concat(statusReport, summary);
            Console.Write(statusReport);
        }
    }
}
