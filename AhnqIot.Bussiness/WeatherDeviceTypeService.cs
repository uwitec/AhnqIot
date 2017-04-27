//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： WeatherDeviceTypeService.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 10:00
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.IO;
using System.Linq;
using System.Text;
using AhnqIot.Bussiness.Core;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Dto;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Hxj.Repository.AhnqIot;
using AhnqIot.Infrastructure.Log;
using NewLife;
using NewLife.Log;

namespace AhnqIot.Bussiness
{
    public class WeatherDeviceTypeService : ServiceBase<WeatherDeviceType, WeatherDeviceTypeDto>,
        IWeatherDeviceTypeService
    {
        //private readonly IAhnqIotRepository<WeatherDeviceType> _weatherDeviceTypeRep;

        public WeatherDeviceTypeService(IAhnqIotRepository<WeatherDeviceType> weatherDeviceTypeRep)
        {
            //_weatherDeviceTypeRep = weatherDeviceTypeRep;
            //if (!_weatherDeviceTypeRep.GetAll().ToList().Any()) 
            
        }

        //todo 数据初始化需迁移位置

        #region 从text文件导入初始化数据

        public override void InitData()
        {
            ImportFromText();
        }
        public void ImportFromText()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Runtime.IsWeb ? "bin" : "", "ExtendResource",
                "WeatherDeviceType.txt");
            if (File.Exists(path))
            {
                 LogHelper.Info("从文件导入农田小气候仪设备类型");
                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    string lastParent = null;
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var arr = line.Split(new char[] { ' ', ',', '|', '_', ',', ',', '\t' },
                            StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length == 0) continue;

                        var code = arr[0]; //上级编码
                        var name = arr[1]; //名称
                        var calc = arr[2]; //计算公式
                        var unit = arr[3]; //单位

                        var entity = new WeatherDeviceType
                        {
                            Serialnum = code,
                            Name = name,
                            Calc = calc,
                            Unit = unit,
                            Introduce = name,
                            ParentSerialnum = lastParent,
                            Remark = "/Content/images/Source/WeatherDeviceType/" + name + ".png"
                        };

                        //var isParent = arr.Length == 3;
                        //if (isParent)//本行是后面类型的父类型
                        //{
                        //    entity.ParentSerialnum = null;
                        //}

                        if(!Repository.Exists(entity.Serialnum))Repository.Add(entity);
                        Repository.Commit();


                        //if (isParent)
                        //{
                        //    lastParent = entity.Serialnum;
                        //}
                        //else
                        //{
                        //    lastParent = null;
                        //}
                    }
                }
            }
        }
        #endregion
    }
}