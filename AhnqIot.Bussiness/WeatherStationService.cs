//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Bussiness
//  FILENAME   ： WeatherStationService.cs
//  AUTHOR     ： 赵虎
//  CREATE TIME： 10:00
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
    public class WeatherStationService : ServiceBase<WeatherStation, WeatherStationDto>, IWeatherStationService
    {
        public IAhnqIotRepository<SysDepartment> SysDepartmentRep { get; set; }

        #region 从text文件导入初始化数据
        public override void InitData()
        {
            ImportFromText();
        }
        public void ImportFromText()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Runtime.IsWeb ? "bin" : "", "ExtendResource",
                "WeatherStation.txt");
            if (File.Exists(path))
            {
                LogHelper.Info("从文件导入农田监测站");

                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line.IsNullOrWhiteSpace()) continue;
                        var arr = line.Split(new char[] { ' ', ',', '\t', }, StringSplitOptions.RemoveEmptyEntries);

                        var depName = arr[2];
                        var dep = SysDepartmentRep.Get(s => s.Name.Equals(depName));
                        var sysDepartmenSerialnum = dep.Serialnum; //预留机构编码，根据机构名查找
                        var code = arr[3];
                        var name = arr[4];
                        var longtitude = arr[5];
                        var latitude = arr[6];
                        var location = arr[8];
                        var createTime = arr[13];
                        var setupTime = arr[14];
                        var updateTime = arr[15];

                        if (!Repository.Exists(code))
                        {
                            var entity = new WeatherStation
                            {
                                Serialnum = code,
                                Introduce = name,
                                Latitude = latitude,
                                Lotitude = longtitude,
                                Location = location,
                                SysDepartmentSerialnum = sysDepartmenSerialnum,
                                CreateTime = Convert.ToDateTime(createTime),
                                SetupTime = Convert.ToDateTime(setupTime),
                                UpdateTime = Convert.ToDateTime(updateTime),
                                Sort = 0
                            };
                            Repository.Add(entity);
                        }
                    }
                }
                if (Repository.InsertList.Count > 0)
                    Repository.Commit();
            }
        }
        #endregion

    }
}