using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScottishPremierLeauge.Models
{
    public class WebModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IImageService>().To<ImageService>();
        }
    }
}