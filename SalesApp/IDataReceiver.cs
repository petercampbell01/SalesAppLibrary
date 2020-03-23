/** Interface is used to specify the DataReceiver for the scanner.
 * This is implemented by the Controller class that then coordinates the sale.
 * 22/03/2020
 * Peter Campbell
 */
using System;

namespace SalesAppLibrary
{
    public interface IDataReceiver
    {
        Boolean ReceiveScanData(string scanIn);
    }
}
