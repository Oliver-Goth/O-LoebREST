using O_LoebREST.Models;

public interface IQuestionRepo
{
    Question AddQuestion(Question question);
    IEnumerable<Question> GetAll();

    Question GetById(int id);
}
 
