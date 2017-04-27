#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： Interface.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:25
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

namespace SmartIot.Tool.Core.Device.TtsDevice.KdxfProtocal
{
    /// <summary>请求接口</summary>
    public interface IRequest
    {
        #region Public Properties

        /// <summary>子命令</summary>
        TtsFunction Function { get; set; }

        #endregion Public Properties
    }

    /// <summary>响应接口</summary>
    public interface IResponse
    {
        #region Public Properties

        /// <summary>子命令</summary>
        TtsFunction Function { get; set; }

        #endregion Public Properties
    }
}