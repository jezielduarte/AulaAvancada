using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Products.Responses
{

    public class ProductResponseItem
    {
        public Guid Id { get; set; }

        public string Reference { get; set; }

        public string Decription { get; set; }

        public decimal Price { get; set; }

    }
    public class ProductResponse
    {
        public List<ProductResponseItem> Data { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }

        public int LastPage { get; set; }
    }
}
