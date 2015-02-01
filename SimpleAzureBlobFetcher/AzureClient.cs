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
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=" + acctName + ";AccountKey=" + acctKey;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            Console.WriteLine("Azure Client Connected.");

            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            ProcessContainers(client.ListContainers());
        }

        private void ProcessContainers(IEnumerable<CloudBlobContainer> enumerable) {
            int counter = 0;
            foreach (CloudBlobContainer container in enumerable) {
                counter++;
                Console.WriteLine("Container {0}: {1}", counter, container.Name);
                ProcessBlobs(container.ListBlobs());
            }
        }

        private void ProcessBlobs(IEnumerable<IListBlobItem> enumerable) {
            int counter = 0;
            foreach (IListBlobItem item in enumerable) {
                if (item.GetType() == typeof(CloudBlockBlob)) {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    counter++;
                    Console.WriteLine("\tBlob {0}: {1}", counter, blob.Name);
                }
            }
        }

    }
}
