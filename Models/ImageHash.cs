using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace Models;
public static class ImageHash
{


    public static string GetImageHash(IFormFile formFile, string userName)
    {

        var md5 = MD5.Create();

        string sSourceData;
        byte[] tmpSource;

        using (var formFileMs = new MemoryStream())
        {
            formFile.CopyTo(formFileMs);
            var formFileBytes = formFileMs.ToArray();
            sSourceData = Convert.ToBase64String(formFileBytes);
        }

        tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData + userName);

        var byteHash = md5.ComputeHash(tmpSource);

        var hash = ByteArrayToString(byteHash);


        return hash;

    }


    public static string ByteArrayToString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        for (i = 0; i < arrInput.Length; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }
}