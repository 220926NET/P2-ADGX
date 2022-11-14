using Azure.Storage.Blobs;
using Azure.Storage;
using Microsoft.AspNetCore.Http;
using Models;

namespace DataAccessLayer;
public class BlobStorage
{




    private readonly BlobServiceClient _blobServiceClient = new BlobServiceClient(new Uri("https://revatureproject2.blob.core.windows.net"), new StorageSharedKeyCredential("revatureproject2", Secrets.blobStorageKey));

    //This class is used to upload a user photo
    //it takes in the user name employee image and extension
    //it uses the username, employeeImage.filename and extension to build the filename to be saved in the database
    public async Task<string> uploadPhoto(string userName, IFormFile employeeImage, string extension)
    {


        BlobContainerClient container = _blobServiceClient.GetBlobContainerClient("userphotos");
        try
        {

            string url = await uploadPhotoToStorage(userName, employeeImage, extension);
            return url;

        }
        // Exception is thrown if user already has a photo with the same name 
        // so delete photo and upload new one 
        catch (Azure.RequestFailedException)
        {


            return "";

        }

    }







    //this method deletes a file from blob storage 
    public async Task<bool> deletePhotoFromStorage(string fileName)
    {
        try
        {
            BlobContainerClient container = _blobServiceClient.GetBlobContainerClient("userphotos");
            Azure.Response response = await container.DeleteBlobAsync(fileName);
            return true;
        }
        catch (Azure.RequestFailedException)
        {
            return false;
        }
    }

    //this method is used to upload a file to blob storage 
    public async Task<string> uploadPhotoToStorage(string fileName, IFormFile photo, string extension)
    {
        string url = "";
        try
        {
            BlobContainerClient container = _blobServiceClient.GetBlobContainerClient("userphotos");
            BlobClient blobClient = container.GetBlobClient(fileName + "." + extension);


            var memoryStream = new MemoryStream();
            await photo.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            url = blobClient.Uri.AbsoluteUri;





        }
        catch (Azure.RequestFailedException)
        {
            Console.WriteLine("error in upload photo blob storage");
        }
        return url;
    }


}