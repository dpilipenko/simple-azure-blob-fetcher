using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SimpleAzureBlobFetcher {
    class AzureClient {

        public void Run(string acctName, string acctKey) {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName="+acctName+";AccountKey="+acctKey;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            Console.WriteLine("Azure Client Connected.");
            Console.WriteLine(storageAccount.FileStorageUri);
        }

    }
}
