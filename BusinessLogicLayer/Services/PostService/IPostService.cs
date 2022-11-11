using Models;
public interface IPostService
{
    Task<ResponseMessage<string>> CreatePost(Post userPost);


}