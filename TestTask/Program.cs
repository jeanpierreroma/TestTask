using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string f = "3+5*(10-5)+50-(5*20-10)";

            StringHelper stringHelper = new StringHelper(f);

            var r = stringHelper.ResolveExample();

            Console.WriteLine(r);
        }        
    }
}
