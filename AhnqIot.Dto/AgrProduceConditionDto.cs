using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace AhnqIot.Dto
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class AgrProduceConditionDto:BaseDto
    {
        public string AgrProductObjectSerialnum { get; set; }
        public string DevelopmentalStage { get; set; }
        public int Month { get; set; }
        public string SuitableCondition { get; set; }
        public string SysAreaSerialnum { get; set; }
        public string Ten { get; set; }
    }
}
