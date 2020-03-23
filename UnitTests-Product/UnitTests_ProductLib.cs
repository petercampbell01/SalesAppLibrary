using System;
using SalesAppLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_Product
{
    [TestClass]
    public class UnitTests_ProductLib
    {
        public Product ProdA;
        public Product ProdB;
        public Product ProdC;
        public Product ProdD;

        public Product Result = new Product()
        {
            ProductCode = "A",
            UnitPrice = 1.25,
            BulkNumber = 3,
            BulkPrice = 3,
            NumberOfItems = 0,
            TotalPrice = 0
        };

        [TestMethod]
        public void Test_ConstructLibClass_correctly()
        {
            double expected = 0;
            double actual = Result.TotalPrice;
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_AddItem()
        {
            double expected = 1.25;
            double actual = Result.AddItem();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }
        [TestMethod]
        public void Test_AddItem_RemoveItem()
        {
            double expected = 1.25;
            Result.AddItem();
            Result.AddItem();
            double actual = Result.RemoveItem();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_BulkPurchase()
        {
            Result.AddItem();
            Result.AddItem();
            double expected = 3;
            double actual = Result.AddItem();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }
        [TestMethod]
        public void Test_BulkIndividualPurchase()
        {
            double expected = 4.25;
            Result.AddItem();
            Result.AddItem();
            Result.AddItem();
            double actual = Result.AddItem();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }
        [TestMethod]
        public void Test_NumberOfItems()
        {
            Result.AddItem();
            Result.AddItem();
            Result.AddItem();
            Result.AddItem();
            Result.AddItem();
            int expected = 5;
            double actual = Result.NumberOfItems;
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }
        [TestMethod]
        public void Test_TestMultipleBulkPurchase()
        {
            Result.AddItem();
            Result.AddItem();
            Result.AddItem();
            Result.AddItem();
            Result.AddItem();
            int expected = 6;
            double actual = Result.AddItem();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        //Test Cart class


        [TestMethod]
        public void Test_MyCart_AddItem()
        {
            Cart myCart = new Cart();
            double expected = 1.25;
            double actual = myCart.AddItem(Result);
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_MyCart_AddItem_Multiple()
        {
            Cart myCart = new Cart();
            double expected = 4.25;
            double actual = myCart.AddItem(Result);
            actual = myCart.AddItem(Result);
            actual = myCart.AddItem(Result);
            actual = myCart.AddItem(Result);
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_MyCart_AddItem_Multiple_TotalCost()
        {
            Cart myCart = new Cart();
            double expected = 4.25;
            myCart.AddItem(Result);
            myCart.AddItem(Result);
            myCart.AddItem(Result);
            myCart.AddItem(Result);
            double actual = myCart.TotalPurchasePrice;
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_DBHandler_GetProductRecord()
        {
            DBHandler myDB = new DBHandler();
            double expected = 1.25;
            double actual = myDB.GetProductRecord("A").UnitPrice;
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }


        [TestMethod]
        public void Test_Controller()
        {
            View myView = new View();
            Scanner myScan = new Scanner();
            Controller terminal = new Controller(myScan, myView);
            terminal.ScanProduct("A");
            double expected = 1.25;
            double actual = terminal.CalculateTotal();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_Controller_SetPrice()
        {
            View myView = new View();
            Scanner myScan = new Scanner();
            Controller terminal = new Controller(myScan, myView);
            double expected = 29.99;
            Product result = terminal.SetPrice("A", 29.99);
            double actual = result.UnitPrice;
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }
        [TestMethod]
        public void Test_Controller_SetBulkPrice()
        {
            View myView = new View();
            Scanner myScan = new Scanner();
            Controller terminal = new Controller(myScan, myView);
            double expected = 50;
            Product result = terminal.SetBulkPrice("A", 2, 50);
            double? actual = result.BulkPrice;
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_Controller_MultipleItems()
        {
            View myView = new View();
            Scanner myScan = new Scanner();
            Controller terminal = new Controller(myScan, myView);
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");
            double expected = 13.25;
            double actual = terminal.CalculateTotal();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_Controller_MultipleProductC()
        {
            View myView = new View();
            Scanner myScan = new Scanner();
            Controller terminal = new Controller(myScan, myView);
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            double expected = 6;
            double actual = terminal.CalculateTotal();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void Test_Controller_MultipleItemsAtoD()
        {
            View myView = new View();
            Scanner myScan = new Scanner();
            Controller terminal = new Controller(myScan, myView);
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            double expected = 7.25;
            double actual = terminal.CalculateTotal();
            string message = String.Format("Expected {0}, Actual {1}", expected, actual);
            Assert.AreEqual(expected, actual, message);
        }
    }
}
