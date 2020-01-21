using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlideShowGallary.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string ImageThumbPath { get; set; }
    }
}