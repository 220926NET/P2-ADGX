using Azure.Storage.Blobs;
using Azure.Storage;
using Microsoft.AspNetCore.Http;
using Models;

namespace DataAccessLayer;
public class BlobStorage
{



    private readonly BlobServiceClient _blobServiceClient = new BlobServiceClient(new Uri("https://storagetestrev.blob.core.windows.net"), new StorageSharedKeyCredential("storagetestrev", Secrets.BlobStorageKey));


    //This class is used to upload a user photo
    //it takes in the user name employee image and extension
    //it uses the username, employeeImage.filename and extension to build the filename to be saved in the database
    public async Task<ResponseMessage<string>> uploadPhoto(string userName, IFormFile employeeImage, string extension)
    {

        ResponseMessage<string> uploadUserPhotoRes = new ResponseMessage<string>();
        BlobContainerClient container = _blobServiceClient.GetBlobContainerClient("userphotos");
        try
        {

            string url = await uploadPhotoToStorage(userName, employeeImage, extension);
            uploadUserPhotoRes.data = url;
            uploadUserPhotoRes.message = $"Successfully uploaded user photo!";
            uploadUserPhotoRes.success = false;

        }
        // Exception is thrown if user already has a photo with the same name 
        // so delete photo and upload new one 
        catch (Azure.RequestFailedException)
        {


            //TODO: Log error 
            uploadUserPhotoRes.data = null;
            uploadUserPhotoRes.message = $"Unexpected error please try again later!";
            uploadUserPhotoRes.success = false;
        }

        return uploadUserPhotoRes;
    }




    public async Task<ResponseMessage<string>> uploadUserPhoto(string fileName, IFormFile employeeImage, string extension)
    {

        ResponseMessage<string> uploadUserPhotoRes = new ResponseMessage<string>();
        BlobContainerClient container = _blobServiceClient.GetBlobContainerClient("userphotos");
        try
        {

            string url = await uploadPhotoToStorage(fileName, employeeImage, extension);
            uploadUserPhotoRes.data = url;
            uploadUserPhotoRes.message = $"Successfully uploaded user photo!";
            uploadUserPhotoRes.success = false;

        }
        // Exception is thrown if user already has a photo with the same name 
        // so delete photo and upload new one 
        catch (Azure.RequestFailedException)
        {

            uploadUserPhotoRes.data = null;
            uploadUserPhotoRes.message = $"You may only upload unique content, please delete old content or change current content.";
            uploadUserPhotoRes.success = false;
        }

        return uploadUserPhotoRes;
    }


    //this method deletes a file from blob storage 
    public async Task deletePhotoFromStorage(string fileName)
    {
        BlobContainerClient container = _blobServiceClient.GetBlobContainerClient("userphotos");
        Azure.Response wasDeleted = await container.DeleteBlobAsync(fileName);
        Console.WriteLine("response code is " + wasDeleted.Status);
    }

    //this method is used to upload a file to blob storage 
    public async Task<string> uploadPhotoToStorage(string fileName, IFormFile photo, string extension)
    {
        BlobContainerClient container = _blobServiceClient.GetBlobContainerClient("userphotos");
        BlobClient blobClient = container.GetBlobClient(fileName + "." + extension);
        MemoryStream memoryStream = new MemoryStream();
        await photo.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        await blobClient.UploadAsync(memoryStream);
        string url = blobClient.Uri.AbsoluteUri;
        return url;
    }


}