using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartIot.Tool.DefaultService.DB.Common
{
   public class AttributeExtend
    {
        public static void SetPropertyVisibility(object obj, string propertyName, bool visible)
        {
            Type type = typeof(BrowsableAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("browsable", BindingFlags.Instance | BindingFlags.NonPublic);
            fld.SetValue(attrs[type], visible);
        }

        public static void SetPropertyReadOnly(object obj, string propertyName, bool readOnly)
        {
            Type type = typeof(System.ComponentModel.ReadOnlyAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("isReadOnly", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            fld.SetValue(attrs[type], readOnly);
        }
    }

    #region 简单下拉框
    public class ModularConverter: StringConverter 
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;//显示下拉框
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var modulars = ModularDevice.FindAll();
            var names =new ArrayList();
            if(modulars!=null&&modulars.Count>0)
            {
                names.AddRange(modulars);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;//下拉框不可编辑
        }
    }

    public class SensorConverter:StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var sensors = Sensor.FindAll();
            var names = new ArrayList();
            if (sensors != null && sensors.Count > 0)
            {
                names.AddRange(sensors);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    public class DeviceTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = DeviceType.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    public class RelayTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = RelayType.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    public class ControlJobTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = ControlJobType.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }


    public class ShowDeviceTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = ShowDeviceType.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    public class CommunicateDeviceConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = CommunicateDevice.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }


    public class FarmConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = Farm.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    public class FacilityTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = FacilityType.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }


    public class CommunicateDeviceTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = CommunicateDeviceType.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    public class ProtocalTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var types = ProtocalType.FindAll();
            var names = new ArrayList();
            if (types != null && types.Count > 0)
            {
                names.AddRange(types);
            }
            return new StandardValuesCollection(names);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }


    #endregion


    #region dynamic combox

    //重写下拉菜单中的项，使之与属性页的项关联
    public abstract class ComboBoxItemTypeConvert : TypeConverter
    {
        public Hashtable myhash = null;
        public ComboBoxItemTypeConvert()
        {
            myhash = new Hashtable();
            GetConvertHash();
        }
        public abstract void GetConvertHash();

        //是否支持选择列表的编辑
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        //重写combobox的选择列表
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            int[] ids = new int[myhash.Values.Count];
            int i = 0;
            foreach (DictionaryEntry myDE in myhash)
            {
                ids[i++] = (int)(myDE.Key);
            }
            return new StandardValuesCollection(ids);
        }
        //判断转换器是否可以工作
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);

        }
        //重写转换器，将选项列表（即下拉菜单）中的值转换到该类型的值
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object obj)
        {
            if (obj is string)
            {
                foreach (DictionaryEntry myDE in myhash)
                {
                    if (myDE.Value.Equals((obj.ToString())))
                        return myDE.Key;
                }
            }
            return base.ConvertFrom(context, culture, obj);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);

        }

        //重写转换器将该类型的值转换到选择列表中
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object obj, Type destinationType)
        {

            if (destinationType == typeof(string))
            {
                foreach (DictionaryEntry myDE in myhash)
                {
                    if (myDE.Key.Equals(obj))
                        return myDE.Value.ToString();
                }
                return "";
            }
            return base.ConvertTo(context, culture, obj, destinationType);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }
    //重写下拉菜单，在这里实现定义下拉菜单内的项
    public class MyComboItemConvert : ComboBoxItemTypeConvert
    {
        private Hashtable hash;
        public override void GetConvertHash()
        {
            try
            {
                myhash = hash;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        public MyComboItemConvert(string str)
        {
            hash = new Hashtable();
            string[] stest = str.Split(',');
            for (int i = 0; i < stest.Length; i++)
            {
                hash.Add(i, stest[i]);
            }
            GetConvertHash();
            value = 0;
        }

        public int value { get; set; }

        public MyComboItemConvert(string str, int s)
        {
            hash = new Hashtable();
            string[] stest = str.Split(',');
            for (int i = 0; i < stest.Length; i++)
            {
                hash.Add(i, stest[i]);
            }
            GetConvertHash();
            value = s;
        }
    }
    #endregion


}
