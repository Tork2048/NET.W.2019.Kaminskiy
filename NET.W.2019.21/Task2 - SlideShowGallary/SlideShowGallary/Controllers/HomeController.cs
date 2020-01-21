using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlideShowGallary.Models;

namespace SlideShowGallary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Image> images = new List<Image>();
            images.Add(new Image { ImageId = 1, Description = "The Woods", ImagePath = @"~/Images/img_woods_wide.jpg", ImageThumbPath = @"~/Images/img_woods.jpg", });
            images.Add(new Image { ImageId = 2, Description = "Cinque Terre", ImagePath = @"~/Images/img_5terre_wide.jpg", ImageThumbPath = @"~/Images/img_5terre.jpg", });
            images.Add(new Image { ImageId = 3, Description = "Mountains and fjords", ImagePath = @"~/Images/img_mountains_wide.jpg", ImageThumbPath = @"~/Images/img_mountains.jpg", });
            images.Add(new Image { ImageId = 4, Description = "Northern Lights", ImagePath = @"~/Images/img_lights_wide.jpg", ImageThumbPath = @"~/Images/img_lights.jpg", });
            images.Add(new Image { ImageId = 5, Description = "Nature and sunrise", ImagePath = @"~/Images/img_nature_wide.jpg", ImageThumbPath = @"~/Images/img_nature.jpg", });
            images.Add(new Image { ImageId = 6, Description = "Snowy Mountains", ImagePath = @"~/Images/img_snow_wide.jpg", ImageThumbPath = @"~/Images/img_snow.jpg", });

            ViewBag.Images = images;
            ViewBag.Path = Url.Content("~/Images/Dawn.jpg");

            return View();
        }        
    }
}