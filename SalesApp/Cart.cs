/** This class keeps track of product items being purchased and 
 * calculates total price of the purchase.
 * 22/03/2020
 * Peter Campbell
 */
using System.Collections.Generic;

namespace SalesAppLibrary
{
    public class Cart
    {

        public double TotalPurchasePrice { get; set; }
        private List<Product> ItemsInCart = new List<Product>();

        public Cart()
        {
            TotalPurchasePrice = 0;
        }

        /** Adds item to ItemsInCart List.
         *  Checks that item is in list. If it is it then updates that instance and calculates total cost.
         *  If item is not in ItemsInCart List, it adds the item to the list and the calculates total cost.
         */
        public double AddItem(Product item)
        {
            if (ItemsInCart.Exists(x => x.ProductCode == item.ProductCode))
            {
                Product updateProduct = ItemsInCart.Find(x => x.ProductCode == item.ProductCode);
                int itemIndex = ItemsInCart.IndexOf(updateProduct);
                ItemsInCart[itemIndex].AddItem();
            }
            else
            {
                item.AddItem();
                ItemsInCart.Add(item);
            }
            return CalculateTotalPrice();
        }

        public double CalculateTotalPrice()
        {
            double sum = 0;
            foreach (Product item in ItemsInCart)
            {
                sum += item.TotalPrice;
            }
            TotalPurchasePrice = sum;
            return sum;
        }

        public List<Product> GetCart()
        {
            return ItemsInCart;
        }

        public void EmptyCart()
        {
            ItemsInCart.Clear();
            TotalPurchasePrice = 0;
        }
    }
}
