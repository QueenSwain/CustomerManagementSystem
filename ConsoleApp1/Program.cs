using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int i, j;
            for(i=1;i<=n;i++)
            {
                for(j=1;j<=i;j++)
                {
                  //  Console.Write(j);
                    Console.Write((char)(j + 64));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
