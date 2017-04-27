using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahnqiot.Web.Api.Models
{
    public class SysMenuModel
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public bool Necessary { get; set; }
        public string ParentSerialnum { get; set; }
        public string SysFunctionSerialnum { get; set; }
        public bool Visiable { get; set; }
    }
}