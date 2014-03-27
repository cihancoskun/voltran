namespace Voltran.Web.Data.Entities
{
    public class Feedback : BaseEntity
    { 
        public string Message { get; set; }
        public string Email { get; set; }
        public bool IsAnonymous { get; set; }
    }
}