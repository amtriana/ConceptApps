using System;
using System.Collections.Generic;

#nullable disable

namespace Prj_RESTAPI_Amth.Model
{
    public partial class Stock
    {
        public string StoreCode { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
