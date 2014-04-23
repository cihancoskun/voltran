using System.Collections.Generic;

namespace Voltran.Web.Data.Entities
{
    public class QuestionSet : BaseEntity
    {
        public string Name { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public virtual ICollection<Question> Questions { get; set; }  
    }
}