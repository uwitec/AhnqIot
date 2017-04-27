using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Device.Led.YXTD.Portocal
{
    /// <summary>
    /// 字体颜色
    /// </summary>
    public enum LedFontColor : uint
    {
        /// <summary>
        /// 0 红色
        /// </summary>
        Red = 0XFFFF0000,

        /// <summary>
        /// 1 绿色
        /// </summary>
        Green=0XFF000000,

        /// <summary>
        /// 2 黄色
        /// </summary>
        Yellow=0X00000000
    }

    /// <summary>
    /// LED屏显示方式
    /// </summary>
    public enum ShowType : ushort
    {

        从左至右 = 0,
        从右至左,
        从两边到中间,
        从中间到两边,
        从上至下,
        从下至上,
        从上下到中间,
        从中间到上下,
        连续左移,
        连续右移,
        连续上移,
        连续下移,
        下沙漏,
        上沙漏,
        平行百叶,
        垂直百叶,
        立即打出,
        随机显示
    }
}
