using Models;

public interface IPostService
{

    Task<ResponseMessage<string>> AddUserPost(Post userPost);

}