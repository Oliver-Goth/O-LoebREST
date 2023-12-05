using O_LoebREST.Models;

public interface IPostRepo
{
    Post AddPost(Post post);
    Post GetPostById(int id);
    void AddPostToRun(int runID, int postId);
}

