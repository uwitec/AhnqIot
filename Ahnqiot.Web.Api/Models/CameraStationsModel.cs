using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahnqiot.Web.Api.Models
{
    public class CameraStationsModel
    {
        public int Channel { get; set; }

        public int DataPort { get; set; }

        public int HttpPort { get; set; }
 
        public string Name { get; set; }

        public int RtspPort { get; set; }

        public DateTime SetupTime { get; set; }

        public string SysDepartmentSerialnum { get; set; }
  
        //public string UserID { get; set; }

        //public string UserPwd { get; set; }
    }
}