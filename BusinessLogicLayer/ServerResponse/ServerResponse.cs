using Models;

namespace BusinessLogicLayer;

public class ServerResponse
{


    public ResponseMessage<string> _response = new ResponseMessage<string>();

    public ResponseMessage<string> InvalidFileResponse()
    {
        return setResponse("Please ensure your profile image is of type .jpg or .png");
    }


    public ResponseMessage<string> UserHasProfilePhotoSet()
    {
        return setResponse("Please delete current profile photo before trying to set a new one");
    }

    public ResponseMessage<string> IssueUploadingToBlobStorage()
    {
        return setResponse("There was an issue uploading photo to blob storage");
    }

    public ResponseMessage<string> IssueUploadingProfilePhotoToDb()
    {
        return setResponse("There was an issue uploading your profile picture to the database, try again later.");
    }

    public ResponseMessage<string> SuccessfullyUploadedProfilePhoto()
    {
        return setResponse("Successfully uploaded profile photo.", true);
    }

    public ResponseMessage<string> DeletingFromBlobStorageFailure()
    {
        return setResponse("Unable to delete profile picture try again later.");
    }
    public ResponseMessage<string> DeletingFromBlobStorageSuccess()
    {
        return setResponse("File has been deleted.");
    }

    public ResponseMessage<string> uploadUserHobbiesFailure()
    {
        return setResponse("Unable to upload user hobbies, try again later.");
    }

    public ResponseMessage<string> uploadUserHobbiesSuccess()
    {
        return setResponse("Successfully uploaded user hobbies.");
    }

    public ResponseMessage<string> UploadProfileInterestsFailure()
    {
        return setResponse("Unable to AddProfile interests");
    }

    public ResponseMessage<string> UploadProfileInterestsSuccess()
    {
        return setResponse("Sucessfully added profile interests");
    }


    public ResponseMessage<string> SqlError()
    {
        return setResponse("Issues with database, please try again later");
    }



    public ResponseMessage<string> setResponse(string message, bool success = false)
    {

        _response.message = message;
        _response.success = success;
        return _response;
    }

}