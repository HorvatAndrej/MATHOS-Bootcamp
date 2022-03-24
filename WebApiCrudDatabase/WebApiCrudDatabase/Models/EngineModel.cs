using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCRUD.Models
{
    public class EngineModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ManufacturerId { get; set; }
        

    }
}