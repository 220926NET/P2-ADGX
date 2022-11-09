using Models;
using Microsoft.AspNetCore.Http;
public interface IProfileService
{

    Task<ResponseMessage<string>> uploadUserPhoto(IFormFile userPhoto);

}