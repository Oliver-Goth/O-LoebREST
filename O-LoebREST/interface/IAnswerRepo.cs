using O_LoebREST.Models;

public interface IAnswerRepo
{
    Answer AddAnswer(Answer answer);
    List<Answer> GetAnswersByQuestion(int questionId);
}
