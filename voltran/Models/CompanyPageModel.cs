using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voltran.Web.Data.Entities;

namespace Voltran.Web.Models
{
    public class CompanyPageModel : BaseModel
    {
        public CompanyModel Company { get; set; }
        public List<ImageModel> Images { get; set; }

        public static CompanyPageModel Map(Company company, List<ImagesOfCompany> imageOfCompany)
        {
            var model = new CompanyPageModel
            {
                Company = new CompanyModel { Id = company.Id,
                                             Name = company.Name, 
                                             LogoUrl = company.LogoUrl, 
                                             Address = company.Address }
            };

            model.Images = new List<ImageModel>();

            if (imageOfCompany.Count() > 0)
            {
                var imageModel = imageOfCompany.Select(ImageModel.Map);

                model.Images.AddRange(imageModel.ToList());
            }
            return model;
        }
    }
}