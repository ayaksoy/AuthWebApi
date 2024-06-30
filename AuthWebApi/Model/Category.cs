using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthWebApi.Model.Abstract;

namespace AuthWebApi.Model
{
    public class Category : CommonProp
    {
        public List<Product>? Products { get; set; }
    }
}