using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
   public  class FarmRepository
    {
        /// <summary>
        /// 获取企业下所有基地
        /// </summary>
        /// <param name="companySerialnum">企业编码</param>
        /// <returns></returns>
        public IEnumerable<Farm> GetByCompanySerialnum(string companySerialnum)
        {
            if (String.IsNullOrWhiteSpace(companySerialnum)) throw new ArgumentNullException("companySerialnum");
            return Farm.FindAllByCompanySerialnum(companySerialnum);
        }
        /// <summary>
        /// 根据编码获取基地
        /// </summary>
        /// <param name="serialnum">基地编码</param>
        /// <returns></returns>
        public Farm GetBySerialnum(string serialnum)
        {
            if (String.IsNullOrWhiteSpace(serialnum)) throw new ArgumentNullException("serialnum");
            return Farm.FindBySerialnum(serialnum);
        }
        /// <summary>
        /// 根据编码删除基地
        /// </summary>
        /// <param name="serialnum">基地编码</param>
        /// <returns></returns>
        public bool DeleteBySerialnum(string serialnum)
        {
            var result = false;
            if (String.IsNullOrWhiteSpace(serialnum)) throw new ArgumentNullException("serialnum");
            var farm = Farm.FindBySerialnum(serialnum);
            if (farm == null) result = false;
            try
            {
                farm.Delete();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
