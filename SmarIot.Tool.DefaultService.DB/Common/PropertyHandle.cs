using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XCode;

namespace SmartIot.Tool.DefaultService.DB.Common
{
    /// <summary>
    /// 实体属性处理
    /// </summary>
    public class PropertyHandle
    {
        #region 反射控制只读、可见属性
        //SetPropertyVisibility(obj,   名称 ,   true); 
        //obj指的就是你的SelectObject，   “名称”是你SelectObject的一个属性 
        //当然，调用这两个方法后，重新SelectObject一下，就可以了。
        /// <summary>
        /// 通过反射控制属性是否只读
        /// </summary>
        ///<param name="obj">
        ///<param name="propertyName">
        ///<param name="readOnly">
        public static void SetPropertyReadOnly(object obj, string propertyName, bool readOnly)
        {
            Type type = typeof(ReadOnlyAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField(propertyName, BindingFlags.NonPublic | BindingFlags.Static);
            fld.SetValue(attrs[type], readOnly);
        }

        /// <summary>
        /// 通过反射控制属性是否可见
        /// </summary>
        ///<param name="obj">
        ///<param name="propertyName">
        ///<param name="visible">
        public static void SetPropertyVisibility(object obj, string propertyName, bool visible)
        {
            Type type = typeof(BrowsableAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
            fld.SetValue(attrs[type], visible);
        }
        #endregion

        #region 批量处理字段只读属性
        public static void SetPropertysReadOnly(IEntity T,bool isReadOnly)
        {
            T.GetType().GetProperties().ForEachX(p=> {
                if(p!=null&&!p.Name.EqualIgnoreCase("Item"))SetPropertyReadOnly(T, p.Name, isReadOnly);
            });
        }

        public static void SetPropertysReadOnly(IEntity T1,IEntity T2, bool isReadOnly)
        {
            T1.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item"))
                    SetPropertyReadOnly(T1, p.Name, isReadOnly);
            });
            T2.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T2, p.Name, isReadOnly);
            });
        }

        public static void SetPropertysReadOnly(IEntity T1, IEntity T2, IEntity T3, bool isReadOnly)
        {
            T1.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T1, p.Name, isReadOnly);
            });
            T2.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T2, p.Name, isReadOnly);
            });
            T3.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T3, p.Name, isReadOnly);
            });

        }
        public static void SetPropertysReadOnly(IEntity T1, IEntity T2, IEntity T3, IEntity T4, bool isReadOnly)
        {
            T1.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T1, p.Name, isReadOnly);
            });
            T2.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T2, p.Name, isReadOnly);
            });
            T3.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T3, p.Name, isReadOnly);
            });
            T4.GetType().GetProperties().ForEachX(p => {
                if (p != null && !p.Name.EqualIgnoreCase("Item")) SetPropertyReadOnly(T4, p.Name, isReadOnly);
            });

        }
        #endregion

    }
}
