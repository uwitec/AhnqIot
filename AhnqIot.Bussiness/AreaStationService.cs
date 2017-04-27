using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Hxj.DbModel;
using AhnqIot.Dto;
using AhnqIot.Hxj.Repository.AhnqIot;
using AutoMapper;
using System.IO;
using AhnqIot.Bussiness.Core;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;

namespace AhnqIot.Bussiness
{
    [InitData(4)]
    public class AreaStationService : ServiceBase<AreaStation, AreaStationDto>, IAreaStationService
    {
        public IAhnqIotRepository<SysDepartment> sysDepartRep { get; set; }
        public AreaStationService(IAhnqIotRepository<SysDepartment> sysDepartmentRep)
        {
            sysDepartRep = sysDepartmentRep;
            //AhnqIotContainer.Container.Resolve<IAhnqIotRepository<SysDepartment>>();
        }

        #region 从text文件导入初始化数据

        public override void InitData()
        {
            ImportFromText();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        public void ImportFromText()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NewLife.Runtime.IsWeb ? "bin" : "", "ExtendResource", "AreaStation.txt");
            if (File.Exists(path))
            {
                LogHelper.Info("从文件导入实景监测站");
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    sr.ReadLine(); //跳过第一行
                    sr.ReadLine(); //跳过第二行
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line.IsNullOrWhiteSpace()) continue;

                        var arr = line.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length == 7)
                        {
                            var depName = arr[6];
                            var dep = sysDepartRep.Get(s => s.Name.Equals(depName));

                            AddEntity(arr[1], arr[4], arr[2], arr[3], dep.Serialnum); //机构编码要根据机构名获取，预留
                        }
                    }
                }
                if (Repository.InsertList.Count > 0)
                {
                    var result = Repository.Commit();
                    LogHelper.Info("导入完毕,共导入{0}条记录", result);
                }
                else
                {
                    LogHelper.Info("导入完毕,共导入0条记录");
                }
            }
        }

        /// <summary>
        /// 添加监测站
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="lontitude"></param>
        /// <param name="latitude"></param>
        private void AddEntity(string code, string name, string lontitude, string latitude, string sysDepartmentSerialnum)
        {
            if (Repository.Exists(code)) return;
            var entity = new AreaStation();
            entity.Serialnum = code;
            entity.Remark = name;
            entity.SysDepartmentSerialnum = ""; //todo 修正实景监测站所属机构
            entity.StationCode = code;
            entity.SysDepartmentSerialnum = sysDepartmentSerialnum;
            entity.CreateTime = DateTime.Now;
            //entity.Temprature = 0;
            //entity.Humidity = 0;
            //entity.Rainfall = 0;
            //entity.WindSpeed = 0;
            //entity.WindDirection = 0;
            //entity.Atmosphere = 0;
            entity.Addr = name + "监测站";
            entity.Lontitude = lontitude;
            entity.Latitude = latitude;
            entity.UpdateTime = DateTime.Now;
            entity.Remark = "";
            entity.Sort = 0;
            Repository.Add(entity);
        }
        #endregion
    }
}
