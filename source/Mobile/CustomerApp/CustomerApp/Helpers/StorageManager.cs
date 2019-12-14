using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Helpers
{
    public class StorageManager
    {
        public async Task<string> UploadImage(string ImageFileName, Stream fileStream)
        {
            string FileUrl = "";
            string StorageAccountName = "starastoragefs";
            string StorageAccountKey = "C9X2D2U/GqY/l+O0bw0RQ0DTci/Jfh8jhmSq/Km5fwX+Lg5NtD9mEri59qF3fNNjXlHEMiiygIAm9G82LlrIpw==";

            CloudStorageAccount storageAccount;
            storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + StorageAccountName + ";AccountKey=" + StorageAccountKey);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("customerrequests");

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(ImageFileName);

            await blockBlob.UploadFromStreamAsync(fileStream);


            FileUrl = "https://" + StorageAccountName + ".blob.core.windows.net/customerrequests/" + ImageFileName;

            return FileUrl;
        }
    }
}
