// using Models;
// using DataAccessLayer;

// public class PostService : IPostService
// {

//     private readonly Repository _repo;

//     private readonly BlobStorage _blobStorage;
//     public PostService(Repository repo, BlobStorage blobStorage)
//     {
//         _blobStorage = blobStorage;
//         _repo = repo;
//     }
//     public async Task<ResponseMessage<string>> AddUserPost(PostDto userPost)
//     {
//         ResponseMessage<string> addUserPostRes = new ResponseMessage<string>();


//         if (!Validator.IsFileValid(userPost.Image))
//         {
//             addUserPostRes.message = "Please ensure your image is of type .jpg or .png";
//             addUserPostRes.success = false;
//             return addUserPostRes;
//         }

//         if (userPost.Image != null)
//         {
//             string userPostImageHash = ImageHash.GetImageHash(userPost.Image, userPost.Text);

//             string completeHash = userPostImageHash;

//             // if (!_repo.UserImageAlreadyExists(completeHash))
//             // {

//             //     addUserPostRes = await _blobStorage.uploadUserPhoto(completeHash, userPost.Image, userPost.Image.FileName.Split(".")[1]);
//             //     //upload to blob storage , retrieve url and 
//             //     // upload to database 

//             // }
//             // else
//             // {
//             //     // upload photo to blob storage
//             //     // add photo, description, title to database 
//             //     addUserPostRes.message = "Please ensure your post is unique and reupload";
//             //     addUserPostRes.success = false;
//             // }
//         }

//         return addUserPostRes;

//     }

// }