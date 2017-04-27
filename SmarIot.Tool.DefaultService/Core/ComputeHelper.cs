#region Code File Comment

// SOLUTION   ： AWIOT - Device
// PROJECT    ： SmartIot.Tool.DefaultService
// FILENAME   ： ComputeHelper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-09-30 10:43
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using NewLife.Reflection;
using System;
using System.Globalization;

namespace SmartIot.Tool.DefaultService.Core
{
    public class ComputeHelper
    {
        public static decimal CalcValue(string computeString, int value, int accuracy = 0)
        {
            if (computeString.IsNullOrWhiteSpace()) computeString = "x*1";

            try
            {
                var se = ScriptEngine.Create(computeString);
                // 如果Method为空说明未编译，可设置参数
                if (se.Method == null)
                {
                    se.Parameters.Add("x", typeof (int));
                }
                // 脚本固定返回Object类型，需要自己转换
                var result = se.Invoke(value);
                return Math.Round(decimal.Parse(result + ""), accuracy);
            }
            catch (Exception ex)
            {
                return -999;
            }
        }

        public static string CalcString(string computeString, int value)
        {
            if (computeString.IsNullOrWhiteSpace()) return null;

            try
            {
                var se = ScriptEngine.Create(computeString);
                // 如果Method为空说明未编译，可设置参数
                if (se.Method == null)
                {
                    se.Parameters.Add("x", typeof (int));
                }
                // 脚本固定返回Object类型，需要自己转换
                var result = se.Invoke(value);

                decimal dd = 0;
                if (decimal.TryParse(result + "", out dd))
                {
                    return Math.Round(dd, 1).ToString(CultureInfo.InvariantCulture);
                }

                return result + "";
            }
            catch (Exception ex)
            {
                return "NaN";
            }
        }
    }
}