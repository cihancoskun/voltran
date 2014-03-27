using System.Linq;
using System.Threading.Tasks;

using Voltran.Web.Data.Entities;
using Voltran.Web.Helpers;

namespace Voltran.Web.Services
{
    public class FeedbackService : BaseService, IFeedbackService
    {
        public Task<bool> CreateFeedback(string message, string email)
        {
            if (string.IsNullOrEmpty(message)) return Task.FromResult(false);

            if (string.IsNullOrWhiteSpace(email))
            {
                email = ConstHelper.Anonymous;
            }

            var feedback = new Feedback
            { 
                Message = message,
                Email = email
            };

            var user = Context.Set<User>().FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                feedback.IsAnonymous = true;
                feedback.CreatedBy = user.Id;
            }

            Context.Set<Feedback>().Add(feedback);

            return Task.FromResult(Context.SaveChanges() > 0);
        } 

        public Task<PagedList<Feedback>> GetFeedbacks(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = Context.Set<Feedback>().Where(x => !x.IsDeleted);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<Feedback>(pageNumber, ConstHelper.PageSize, count, items));
        }
  
        public Task<bool> ChangeStatus(long feedBackId, bool isActive)
        {
            if (feedBackId < 1) return Task.FromResult(false);

            var feedback = Context.Set<Feedback>().FirstOrDefault(x => x.Id == feedBackId);
            if (feedback == null) return Task.FromResult(false);

            feedback.IsActive = !isActive;

            return Task.FromResult(Context.SaveChanges() > 0);
        }
    }

    public interface IFeedbackService
    {
        Task<bool> CreateFeedback(string message, string email); 
        Task<PagedList<Feedback>> GetFeedbacks(int pageNumber);
        Task<bool> ChangeStatus(long feedBackId, bool isActive);
    }
}