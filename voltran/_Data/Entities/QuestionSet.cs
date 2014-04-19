using System.Collections.Generic;

namespace Voltran.Web.Data.Entities
{
    public class QuestionSet : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }  
    }
}