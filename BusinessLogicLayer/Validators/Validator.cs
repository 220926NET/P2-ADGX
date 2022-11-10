using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer;
public static class Validator
{

    // a class method to verify if a file is of type jpg or png 
    public static bool IsFileValid(IFormFile? file)
    {
        bool isAllowed = false;
        if (file == null)
        {
            return false;
        }
        try
        {
            string fileExtension = file.FileName.Split(".")[1];
            if (fileExtension == "jpg" || fileExtension == "png")
            {
                Console.WriteLine("true");
                isAllowed = true;
            }
        }
        catch (IndexOutOfRangeException)
        {
            isAllowed = false;

        }

        return isAllowed;
    }



}