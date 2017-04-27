using System.Collections.Generic;

namespace SmartIot.Tool.API.Core
{
    public interface IApiRequest
    {
        /// <summary>
        /// API公共部分地址
        /// </summary>
        string ApiAddress { get; set; }

        #region 安全验证

        string GetFarmKey(string uid, string pwd, string farmId);

        #endregion 安全验证

        IEnumerable<dynamic> GetFacilityTypes();

        IEnumerable<dynamic> GetDeviceTypes();
    }
}