/** Scanner Class is written to scan input and then 
 * push input to a DataReceiver that then uses it 
 * to calculate user purchases. 
 * Uses method overloading to simplify testing.
 * 22/03/2020
 * Peter Campbell
 */
using System;
namespace SalesApp
{
    public class Scanner
    {
        private IDataReceiver DataReceiver;

        public void AddDataReceiver(IDataReceiver dataReceiver)
        {
            DataReceiver = dataReceiver;
        }

        public void ScanProduct()
        {
            Console.Write("Enter product code: ");
            DataReceiver.ReceiveScanData(Console.ReadLine());
        }

        public void ScanProduct(string code)
        {
            DataReceiver.ReceiveScanData(code);
        }
    }
}
