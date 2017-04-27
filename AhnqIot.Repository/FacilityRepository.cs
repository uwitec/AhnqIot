using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Dal;
namespace AhnqIot.Repository
{
  public  class FacilityRepository
    {
        /// <summary>
        /// 根据基地编码获取所有设施
        /// </summary>
        /// <param name="farmSerialnum">基地编码</param>
        /// <returns></returns>
        public IEnumerable<Facility> GetByFarmSerialnum(string farmSerialnum)
        {
            if (string.IsNullOrWhiteSpace(farmSerialnum)) throw new ArgumentNullException("farmSerialnum");
            return Facility.FindAllByFarmSerialnum(farmSerialnum);
        }
        /// <summary>
        /// 根据设施编码删除设施
        /// </summary>
        /// <param name="serialnum">设施编码</param>
        /// <returns></returns>
        public bool DeleteBySerialnum(string serialnum)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(serialnum)) throw new ArgumentNullException("serialnum");
            var facility = Facility.FindBySerialnum(serialnum);
            if (facility == null) result = false;
            try
            {
                facility.Delete();
                result = true;
            }
            catch (Exception ex)
            {

                //throw;
            }
            return result;
        }
    }
}
