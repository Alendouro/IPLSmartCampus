using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorsDBAPI.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int id_sensor { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime Date { get; set; }
    }
}