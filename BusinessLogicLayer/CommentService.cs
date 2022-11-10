using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public interface ICommentService
    {
        List<Comment> GetPostComments(int postId);
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository commentRepository;

        public CommentService(ICommentsRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public List<Comment> GetPostComments(int postId)
        {
            return commentRepository.GetPostComments(postId);
        }
    }
}
