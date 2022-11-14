using Microsoft.AspNetCore.Http;

public interface IBlobStorage
{
    Task<string> uploadPhoto(string userName, IFormFile employeeImage, string extension);


}