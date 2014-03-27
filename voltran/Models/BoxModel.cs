using System.Collections.Generic;

using Voltran.Web.Data.Entities;
using Voltran.Web.Helpers;

namespace Voltran.Web.Models
{
    public class BoxModel : BaseModel
    {
        public long Id { get; set; }
        public int BoxNumber { get; set; }
        public string BoxImgUrl { get; set; }
 
        public static BoxModel Map(Company company)
        {
            var model = new BoxModel
            { 
                Id = company.Id,
                BoxNumber = company.BoxNumber,
                BoxImgUrl = company.BoxImgUrl
            };
            return model;
        }
    }
}