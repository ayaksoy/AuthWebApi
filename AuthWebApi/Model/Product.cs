using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthWebApi.Model.Abstract;

namespace AuthWebApi.Model
{
    public class Product : CommonProp
    {
        public int Stock { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}