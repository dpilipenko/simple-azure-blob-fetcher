using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleAzureBlobFetcher {
    class Program {

        static int EXPECTED_ARG_LENGTH = 2;

        static void Main(string[] args) {
            Console.WriteLine("Start");

            Stopwatch stopwatch = new Stopwatch();

            if (args.Length < EXPECTED_ARG_LENGTH) {
                HandleInputTooLittle();
            } else 

            if (args.Length > EXPECTED_ARG_LENGTH) {
                HandleInputTooLarge();
            } else

            if (args.Length == EXPECTED_ARG_LENGTH) {
                stopwatch.Start();
                HandleInput(args);
                stopwatch.Stop();
            }
            Console.WriteLine(String.Format("Done. Took {0} seconds", stopwatch.ElapsedMilliseconds / 1000));
            Console.ReadLine();
        }

        private static void HandleInput(string[] args) {
            string ACCT_NAME = args[0];
            string ACCT_KEY = args[1];

            DirectoryInfo outputDir = GetOrCreateOutputFolder();

            new AzureClient().Run(ACCT_NAME, ACCT_KEY, outputDir);
            Process.Start(new ProcessStartInfo() { 
                FileName = outputDir.ToString(),
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private static DirectoryInfo GetOrCreateOutputFolder() {
            DirectoryInfo dir = new DirectoryInfo("Output");
            if (dir.Exists) {
                Console.WriteLine("Folder ./Output/ already exists, deleting contents");
                foreach (DirectoryInfo info in dir.GetDirectories()) {
                    info.Delete(true);
                }
                foreach (FileInfo info in dir.GetFiles()) {
                    info.Delete();
                }
                Console.WriteLine("Deleted.");
            } else {
                dir.Create();
                Console.WriteLine("Created folder ./Output/");
            }
            return dir;
        }

        private static void HandleInputTooLittle() {
            Console.WriteLine(String.Format("Please Include Only {0} Arguments: Account_Name Account_Key"), EXPECTED_ARG_LENGTH);
        }

        private static void HandleInputTooLarge() {
            Console.WriteLine(String.Format("Please Include Only {0} Arguments: Account_Name Account_Key"), EXPECTED_ARG_LENGTH);
        }
    }
}
