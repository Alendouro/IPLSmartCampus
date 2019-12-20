using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorsDBAPI.Models
{
    public class SensorData
    {
        public int id_sensor { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public int Battery { get; set; }
        public DateTime Date { get; set; }
    }
}