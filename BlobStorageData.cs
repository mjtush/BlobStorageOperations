using System.Configuration;
using System;

namespace BlobStorageOperations
{
    static class BlobStorageData
    {
        // TODO: Add your connection string here:
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["MyBlobStorageConnection"].ConnectionString;
        private static readonly string _blobContainerName = "stories";
        private static readonly string _blobName = "matstory.html";

        public static string ConnectionString
        {
            get => _connectionString;
        }

        public static string BlobContainerName
        {
            get => _blobContainerName;
        }

        public static string BlobName
        {
            get => _blobName;
        }

    }
}
