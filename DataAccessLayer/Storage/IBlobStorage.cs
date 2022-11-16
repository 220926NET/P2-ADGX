using Microsoft.AspNetCore.Http;
namespace DataAccessLayer;
public interface IBlobStorage
{
    Task<string> uploadPhoto(string userName, IFormFile employeeImage, string extension);

    Task<string> uploadPhotoToStorage(string fileName, IFormFile photo, string extension);
    Task<bool> deletePhotoFromStorage(string fileName);

}