namespace Voltran.Web.Data.Entities
{
    public class Question : BaseEntity
    {
        public int QuestionNo { get; set; }
        public string QuestionText { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string RightAnswer { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public long? QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; }
    }
}