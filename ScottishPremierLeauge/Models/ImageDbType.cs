using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScottishPremierLeauge.Models
{
    public class ImageDbType
    {
        public byte[] ImageData { get; set; }
        public string Name { get; set; }
        public string  OriginalPath { get; set; }
    }
}