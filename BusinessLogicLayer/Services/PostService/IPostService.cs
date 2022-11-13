using Models;
public interface IPostService
{
    Task<ResponseMessage<string>> CreatePost(NewPost userPost);


}