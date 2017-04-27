using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Dal;
using XCode;
namespace AhnqIot.Repository
{
  public class CompanyRepository
    {
        /// <summary>
        /// 获取所有企业
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Company> GetAll()
        {
            return Company.FindAll();
        }
        /// <summary>
        /// 根据企业编码查找企业
        /// </summary>
        /// <param name="serialNum">企业编码</param>
        /// <returns></returns>
        public Company GetBySerialnum(string serialNum)
        {
            if (String.IsNullOrWhiteSpace(serialNum)) throw new ArgumentNullException("serialNum");
            return Company.FindBySerialnum(serialNum);
        }
        /// <summary>
        /// 根据系统机构编码获取企业
        /// </summary>
        /// <param name="sysDepartSerialnum">系统编码</param>
        /// <returns></returns>
        public IEnumerable<Company> GetBySysDepartSerialnum(string sysDepartSerialnum)
        {
            if (String.IsNullOrWhiteSpace(sysDepartSerialnum)) throw new ArgumentNullException("sysDepartSerialnum");
            return Company.FindAllBySysDepartmentSerialnum(sysDepartSerialnum);
        }
    }
}
