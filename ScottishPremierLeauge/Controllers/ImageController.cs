using ScottishPremierLeauge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScottishPremierLeauge.Controllers
{
    public class ImageController : Controller
    {
        private IImageService service;

        public ImageController(IImageService model)
        {
            this.service = model;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Success() 
        {
            return View();
        }

        public ActionResult SaveImage(HttpPostedFileBase image) 
        {
            if(image != null && image.ContentLength > 0)
            {
                var imageName = image.FileName;
                var imageData = new byte[image.ContentLength];
                image.InputStream.Read(imageData, 0, image.ContentLength);
                service.SaveImage(imageData, image.FileName, @"C:\Temp");
            }

            var result = service.ReadImage(1);

            return RedirectToAction("Success", result);           
        }

        public ActionResult ReadImage(int imageId) 
        {
           var result = service.ReadImage(imageId);

           return View("Success", result);
        }
    }
}