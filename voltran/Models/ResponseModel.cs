namespace Voltran.Web.Models
{
    public class ResponseModel : BaseModel
    {
        public bool Ok { get; set; }
        public object Result { get; set; }
    }
}