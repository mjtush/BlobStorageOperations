using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure;

namespace BlobStorageOperations
{
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            try
            {
                await CreateCOntainerAndUploadBlobAsync();

            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static async Task CreateCOntainerAndUploadBlobAsync()
        {
            // Create the Blob Container
        }
    }
}
