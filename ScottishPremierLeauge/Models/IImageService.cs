using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ScottishPremierLeauge.Models
{
    public interface IImageService
    {
       int SaveImage(byte[] imageData, string name, string originalPath);
       ImageDbType ReadImage(int imageId);
    }
}