using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{

    [Serializable]
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public  class FarmDto : BaseDto
    {
        public string Address { get; set; }
        public string APIKey { get; set; }
        public string AreaStationSerialnum { get; set; }
        public string CompanySerialnum { get; set; }
        public string ContactMan { get; set; }
        public string ContactPhone { get; set; }
        public string Introduce { get; set; }
        public string Latitude { get; set; }
        public string Location { get; set; }
        public string Lotitude { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public bool Status { get; set; }
        public string SysDepartmentSerialnum { get; set; }
        public string UploadPassword { get; set; }


    }
}
