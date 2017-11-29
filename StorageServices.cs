using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace HackfestNov30_Activity1
{
    public class StorageServices
    {
        static string account = CloudConfigurationManager.GetSetting("StorageAccountName");
        static string key = CloudConfigurationManager.GetSetting("StorageAccountKey");

           
        public CloudBlobContainer GetCloudBlobContainer()
        {

            string connString = "DefaultEndpointsProtocol=https;AccountName=vianeyhackest1;AccountKey=uRfKt6VUvYBYdeR99ej9o4yRMoXHih0I4EqgHfOvoeQE5XU9QAJybQ4X/2//8wRcBlwBXxaZnhZdHmw2wZrgYQ==;EndpointSuffix=core.windows.net";
            string destContainer = "imagerecognition";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(destContainer);
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

            }
            return blobContainer;

        }
    }
}

