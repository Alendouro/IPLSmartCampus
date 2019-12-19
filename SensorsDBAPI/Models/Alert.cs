using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorsDBAPI.Models
{
    public class Alert
    {
        public int id { get; set; }

        public string type { get; set; }

        public string condition { get; set; }

        public float value { get; set; }

        public float valueMax { get; set; }

        public string state { get; set; }
    }
}