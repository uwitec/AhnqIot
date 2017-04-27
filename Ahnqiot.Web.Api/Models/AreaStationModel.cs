using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahnqiot.Web.Api.Models
{
    public class AreaStationModel
    {
        public decimal Atmosphere { get; set; }

        public decimal Humidity { get; set; }
  
        public decimal Rainfall { get; set; }

        public string StationCode { get; set; }

        public string SysDepartmentSerialnum { get; set; }

        public decimal Temprature { get; set; }

        public int WindDirection { get; set; }

        public decimal WindSpeed { get; set; }
    }
}