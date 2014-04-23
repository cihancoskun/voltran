using Voltran.Web.Data.Entities;

namespace Voltran.Web.Models
{
    public class ImageModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] ByteData { get; set; }
        public string Extension { get; set; }

        public static ImageModel Map(ImagesOfCompany image)
        {
            var model = new ImageModel
            {
                Id = image.Id,
                Name = image.Name,
                ByteData = image.ByteData,
                Extension = image.Extension
            };
            return model;
        }
    }
}