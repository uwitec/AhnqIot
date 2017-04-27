#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： ControlUnitAttribute.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-11 10:20
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;

namespace SmartIot.Api.Protocal.Common.ControlDevice
{
    public class ControlUnitAttribute : Attribute
    {
        public ControlUnitAttribute()
        {
            IsControlUnit = true;
        }

        public ControlUnitAttribute(string name) : this()
        {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public bool IsControlUnit { get; set; }
    }
}