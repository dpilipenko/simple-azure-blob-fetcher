using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace SimpleAzureBlobFetcher {
    class AzureClient {

        public void Run(string acctName, string acctKey, DirectoryInfo dir) {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=" + acctName + ";AccountKey=" + acctKey;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            Console.WriteLine("Azure Client Connected");
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            
            Console.WriteLine("Begin downloading of files...");
            ProcessContainers(client.ListContainers(), dir);
            Console.WriteLine("...Downloaded all files");
        }

        private void ProcessContainers(IEnumerable<CloudBlobContainer> enumerable, DirectoryInfo dir) {
            int counter = 0;
            foreach (CloudBlobContainer container in enumerable) {
                counter++;

                DirectoryInfo containerDir = dir.CreateSubdirectory(container.Name);

                ProcessBlobs(container.ListBlobs(), containerDir);
            }
        }

        private void ProcessBlobs(IEnumerable<IListBlobItem> enumerable, DirectoryInfo dir) {
            int counter = 0;
            foreach (IListBlobItem item in enumerable) {
                if (item.GetType() == typeof(CloudBlockBlob)) {
                    counter++;
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    using (var fileStream = System.IO.File.OpenWrite(dir.ToString() + @"\" + blob.Name)) {
                        blob.DownloadToStream(fileStream);
                    }

                }
            }
        }

    }
}
