using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Common.cs
{
    public class LoggingService
    {
        public static void WriteToFile(List<ILoggable> ChangedItems) //we will pass the list(change items list) of all the objects(product,customer,order) needs to pass
        {
            foreach (var item in ChangedItems)
            {
                
                Console.WriteLine(item.Log()); //calling business object
            }
        }
    }
}
