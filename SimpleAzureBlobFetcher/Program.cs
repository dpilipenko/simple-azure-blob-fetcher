using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAzureBlobFetcher {
    class Program {

        static int EXPECTED_ARG_LENGTH = 2;

        static void Main(string[] args) {
            Console.WriteLine("Start.");
            if (args.Length < EXPECTED_ARG_LENGTH) {
                HandleInputTooLittle();
            } else 

            if (args.Length > EXPECTED_ARG_LENGTH) {
                HandleInputTooLarge();
            } else

            if (args.Length == EXPECTED_ARG_LENGTH) {
                HandleInput(args);
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        private static void HandleInput(string[] args) {
            string ACCT_NAME = args[0];
            string ACCT_KEY = args[1];


            new AzureClient().Run(ACCT_NAME, ACCT_KEY);
        }

        private static void HandleInputTooLittle() {
            Console.WriteLine(String.Format("Please Include Only {0} Arguments: Account_Name Account_Key"), EXPECTED_ARG_LENGTH);
        }

        private static void HandleInputTooLarge() {
            Console.WriteLine(String.Format("Please Include Only {0} Arguments: Account_Name Account_Key"), EXPECTED_ARG_LENGTH);
        }
    }
}
