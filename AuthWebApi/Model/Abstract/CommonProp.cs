using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthWebApi.Model.Abstract
{
    public class CommonProp
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsStatus { get; set; } = true;
        public bool IsDelete { get; set; } = false;
    }
}