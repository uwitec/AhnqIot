using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Hxj.Repository.Helper
{
    public class PropertyComparer<T> : IEqualityComparer<T>
    {
        private PropertyInfo _PropertyInfo;
        /// <summary>
        /// 通过propertyName 获取PropertyInfo对象    
        /// </summary>
        /// <param name="propertyName"></param>
        public PropertyComparer(string propertyName)
        {
            _PropertyInfo = typeof(T).GetProperty(propertyName,
            BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (_PropertyInfo == null)
            {
                throw new ArgumentException(string.Format("{0} is not a property of type {1}.",
                    propertyName, typeof(T)));
            }
        }
        #region IEqualityComparer<T> Members
        public bool Equals(T x, T y)
        {
            object xValue = _PropertyInfo.GetValue(x, null);
            object yValue = _PropertyInfo.GetValue(y, null);
            if (xValue == null)
                return yValue == null;
            return xValue.Equals(yValue);
        }
        public int GetHashCode(T obj)
        {
            object propertyValue = _PropertyInfo.GetValue(obj, null);
            if (propertyValue == null)
                return 0;
            else
                return propertyValue.GetHashCode();
        }
        #endregion
    }
}
