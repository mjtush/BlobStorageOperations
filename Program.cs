using System;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using static BlobStorageOperations.BlobStorageData;

namespace BlobStorageOperations
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                await CreateContainerAndUploadBlobAsync();

            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static async Task CreateContainerAndUploadBlobAsync()
        {
            // Create the Blob Container
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);

            BlobContainerClient blobContainerClient =
                blobServiceClient.GetBlobContainerClient(BlobContainerName);

            Console.WriteLine($"Creating blob container '{BlobContainerName}'");

            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);

            // Upload the blob 
            BlobClient blobClient = blobContainerClient.GetBlobClient(BlobName);

            Console.WriteLine($"Uploading blob '{blobClient.Name}'");
            Console.WriteLine($"   > {blobClient.Uri}");

            string fileToUploadPath = ConfigurationManager.AppSettings["FileToUploadPath"];
            using FileStream fileStream = File.OpenRead(fileToUploadPath);
            {
                await blobClient.UploadAsync(fileStream,
                    new BlobHttpHeaders()
                    {
                        ContentType = "text/html"
                    });
            }
        }
    }
}
