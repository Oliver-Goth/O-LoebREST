using O_LoebREST.Models;

public interface IPostRepo
{
    Post AddPost(Post post);
    IEnumerable<Post> GetAllRunId();
    IEnumerable<Post> GetAllPost();
    Post GetPostById(int id);
    void AddPostToRun(int runID, int postId);
}

