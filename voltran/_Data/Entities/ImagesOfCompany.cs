using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voltran.Web.Data.Entities
{
    public class ImagesOfCompany : BaseEntity
    {
        public string Name { get; set; }
        public byte[] ByteData { get; set; }
        public string Extension { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}