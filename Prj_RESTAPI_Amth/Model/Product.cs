using System;
using System.Collections.Generic;

#nullable disable

namespace Prj_RESTAPI_Amth.Model
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string LotCode { get; set; }
        public decimal? ListPrice { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
