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

        public static CompanyPageModel Map(Company company)
        {
            var model = new CompanyPageModel
            {
                Company = new CompanyModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    LogoUrl = company.LogoUrl,
                    Address = company.Address
                },
                Images = new List<ImageModel>()
            };

            if (!company.ImagesOfCompany.Any()) return model;

            var imageModel = company.ImagesOfCompany.Where(x => !x.IsDeleted 
                                                                 && x.IsActive).Select(ImageModel.Map);

            model.Images.AddRange(imageModel.ToList());
            return model;
        }
    }
}