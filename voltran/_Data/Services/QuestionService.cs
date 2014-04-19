using System.Linq;
using System.Threading.Tasks;
using Voltran.Web.Data.Entities;

namespace Voltran.Web.Services
{
    public class QuestionService : BaseService, IQuestionService
    {
        public Task<bool> IsAnswerCorrect(long questionId, string answer)
        {
            return Task.FromResult(true); ;
        }

        public Task<Question> GetNextQuestion(long questionId)
        {
            if (questionId < 1) return null;

            var query = Context.Questions.Where(x => !x.IsDeleted
                                                        && x.Id == questionId 
                                                        && x.IsActive);

            var currentQuestion = query.FirstOrDefault();

            query = Context.Questions.Where(x => !x.IsDeleted 
                                                      && x.IsActive
                                                      && x.CompanyId == currentQuestion.CompanyId
                                                      && x.QuestionSetId == currentQuestion.QuestionSetId
                                                      && x.QuestionNo == currentQuestion.QuestionNo + 1);

            var nextQuestion = query.FirstOrDefault();

            return Task.FromResult(nextQuestion);
        }
    }

    public interface IQuestionService
    {
        Task<bool> IsAnswerCorrect(long questionId, string answer);
        Task<Question> GetNextQuestion(long questionId);
    }
}