using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Voltran.Web.Data.Entities;
using Voltran.Web.Models;

namespace Voltran.Web.Services
{
    public class ImageService : BaseService, IImageService
    {
        public Task<List<ImagesOfCompany>> GetImagesOfCompany(long companyId)
        {
            if (companyId < 1) return null;

            var query = Context.ImagesOfCompanies.Where(x => !x.IsDeleted
                                                                && x.CompanyId == companyId
                                                                && x.IsActive);
            var result = query.ToList();

            return Task.FromResult(result);
        }

        public Task<List<ImagesOfCompany>> GetImagesFromUser()
        {
            throw new NotImplementedException();
        }

        //public Task<bool> UploadImage(long companyId, HttpPostedFileBase file)
        //{
        //    ImagesOfCompany image = new ImagesOfCompany()
        //    {
        //        Name = file.FileName.Split('\\').Last(),
        //        CompanyId = companyId,
        //        Size = file.ContentLength,
        //        Title = fileTitle,
        //        Image1 = imageSize,
        //    };
        //    db.Images.AddObject(image);
        //    db.SaveChanges();
        //}

        public async Task<long?> UploadImage(long companyId, ImageModel imageModel)
        {
            if (companyId < 1) return null;

            var image = new ImagesOfCompany
            {
                CompanyId = companyId,
                Name = imageModel.Name,
                ByteData = imageModel.ByteData
            };

            Context.ImagesOfCompanies.Add(image);
            Context.Entry(image).State = EntityState.Added;
            return Context.SaveChanges() > 0 ? await Task.FromResult(image.Id) : -1;
        }
    }

    public interface IImageService
    {
        Task<long?> UploadImage(long companyId, ImageModel imageModel);
        Task<List<ImagesOfCompany>> GetImagesOfCompany(long companyId);
        Task<List<ImagesOfCompany>> GetImagesFromUser();
    }
}