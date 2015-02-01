using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAzureBlobFetcher {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Start.");
            if (args.Length == 2) {
                var arg1 = args[0];
                var arg2 = args[1];
                Console.WriteLine(String.Format("Argument {0}: {1}", 0, arg1));
                Console.WriteLine(String.Format("Argument {0}: {1}", 1, arg2));
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
