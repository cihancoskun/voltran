using Voltran.Web.Data.Entities;

namespace Voltran.Web.Models
{
    public class QuestionModel : BaseModel
    {
        public long Id { get; set; }
        public int QuestionNo { get; set; }
        public string QuestionText { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string RightAnswer { get; set; }
        public bool IsActive { get; set; }

        public static QuestionModel Map(Question question)
        {
            var model = new QuestionModel
            {
                Id = question.Id,
                QuestionNo = question.QuestionNo,
                QuestionText = question.QuestionText,
                Answer1 = question.Answer1,
                Answer2 = question.Answer2,
                Answer3 = question.Answer3,
                Answer4 = question.Answer4,
                RightAnswer = question.RightAnswer,
                IsActive = question.IsActive 
            };
            return model;
        }
    }
}