using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Voltran.Web.Helpers;
using Voltran.Web.Models;
using Voltran.Web.Services;

namespace Voltran.Web.Controllers
{
    public class ImageController : BaseController
    {
        private readonly IImageService _imageService;


        public ImageController(
             IImageService imageService)
        {
            _imageService = imageService;
        }

        //[HttpPost]
        //public ActionResult UploadImage(string id, string fileTitle)
        //{
        //    long companyId;

        //    if (!long.TryParse(id, out companyId)) return RedirectToHome();

        //    try
        //    {
        //        HttpPostedFileBase file = Request.Files[0];
        //        byte[] imageSize = new byte[file.ContentLength];
        //        file.InputStream.Read(imageSize, 0, (int)file.ContentLength);

        //        var result = _imageService.UploadImage(companyId, file);
               
        //        return RedirectToAction("Detail");
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("uploadError", e);
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult UploadImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImages(string id, HttpPostedFileBase[] uploadImages)
        {
            id = "1";
            long companyId;

            if (!long.TryParse(id, out companyId)) return RedirectToHome();

            if (uploadImages.Count() < 1)
            {
                return RedirectToHome();
            }

            foreach (var image in uploadImages)
            {
                if (image.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(image.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(image.ContentLength);
                    }
                    
                    var imageModel = new ImageModel
                    {
                        ByteData = imageData,
                        Name = image.FileName
                    };

                    var imgId = _imageService.UploadImage(companyId, imageModel);
                }
            }
            return RedirectToHome();
        }
    }
}