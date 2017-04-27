using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.DataProcess.Service.Core;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using NewLife.Log;

namespace AhnqIot.WeatherStationDataProcess
{
    // todo 添加机构与农田小气候仪名称映射表
    /// <summary>
    /// 同步农田小气候仪数据
    /// </summary>
    public class WeatherDeviceSyncJob : Job
    {
        private readonly IAreaStationDataInfoService _areaStationDataInfoService;
        private readonly IAreaStationService _areaStationService;

        /// <summary>
        /// 数据库操作类
        /// </summary>
        //private XCode.DataAccessLayer.DAL _dal;
        /// <summary>
        /// 不处理的列
        /// </summary>
        private readonly string[] _exceptColumns = new string[] {"ID", "SID", "TT", "ITT", "AB", "BB"};

        private readonly IWeatherDeviceService _weatherDeviceService;
        private readonly IWeatherDeviceTypeService _weatherDeviceTypeService;
        private readonly IWeatherStationOnlineStatisticsService _weatherStationOnlineStatisticsService;
        private readonly IWeatherStationService _weatherStationService;

        /// <summary>
        /// 连接字符串
        /// </summary>
        private readonly string _connName;

        /// <summary>
        /// 获取数据库所有表名
        /// </summary>
        private readonly string _tableNameSqlCmd;

        public WeatherDeviceSyncJob()
        {
            DisplayName = "农气物联网--农田小气候仪数据同步插件";
            //JobInterval = 5 * 60;
            JobInterval = 10;

            //_connName ="CAWSAnyWhereServer"; 
            _connName =
                "Server= wlw.smartiot.cc,4000;Database=CAWSAnyWhereServer;uid=sa;pwd=*************";
            //"Server = wlw.smartiot.cc,4000; Database = CAWSAnyWhereServer; uid = sa; pwd = 1qaz @WSX providerName=System.Data.SqlClient";

            //_connName = "AWIOT-WeatherDevice";
            try
            {
                //_dal = XCode.DataAccessLayer.DAL.Create(_connName);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString()); //抛出异常
                //_dal = XCode.DataAccessLayer.DAL.Create(_connName);
            }
            _areaStationService = AhnqIotContainer.Container.Resolve<IAreaStationService>();
            _weatherStationOnlineStatisticsService =
                AhnqIotContainer.Container.Resolve<IWeatherStationOnlineStatisticsService>();
            _weatherStationService = AhnqIotContainer.Container.Resolve<IWeatherStationService>();
            _areaStationDataInfoService = AhnqIotContainer.Container.Resolve<IAreaStationDataInfoService>();
            _weatherDeviceService = AhnqIotContainer.Container.Resolve<IWeatherDeviceService>();
            _weatherDeviceTypeService = AhnqIotContainer.Container.Resolve<IWeatherDeviceTypeService>();

            var sqlHelper = new SqlHelper();
            _tableNameSqlCmd = sqlHelper.GetTableNames; //获取所有表名
        }

        public override bool Start()
        {
            CheckDeviceName();
            SyncminuteData();
            return base.Start();
        }

        public override bool Work()
        {
            SyncminuteData();
            return base.Work();
        }

        public override bool Stop()
        {
            return base.Stop();
        }

        private async void CheckDeviceName()
        {
            var list = await _weatherDeviceService.GetAllAsync();
            if (!list.Any()) return;
            list.ToList().ForEach(async item =>
            {
                var watherDeviceType =
                    await _weatherDeviceTypeService.GetByIdAsync(item.WeatherDeviceTypeSerialnum);
                if (item.Name != watherDeviceType.Name)
                    item.Name = watherDeviceType.Name;
                _weatherDeviceService.Update(item);
            });
            XTrace.WriteLine("农田小气候仪设备名称校正完成");
        }


        /// <summary>
        /// 创建监测设备
        /// </summary>
        /// <param name="table"></param>
        private async void CreateWeatherDevice(DataTable table, string tableName)
        {
            var stationSerialnum = tableName;
            var rows = table.Rows;
            foreach (DataRow row in rows)
            {
                var columnName = row[0].ToString();
                var type = _weatherDeviceTypeService.GetById(columnName);
                if (type == null) continue;
                //if (!_exceptColumns.Contains(columnName))
                //{
                var id = stationSerialnum + "-" + columnName;
                //var list = DAL.WeatherDevice.WeatherDevice.FindAll();
                var dto = _weatherDeviceService.GetById(id);
                if (dto != null) continue;
                var device = new WeatherDeviceDto
                {
                    Serialnum = id,
                    //Name = columnName,
                    Name = type.Name,
                    WeatherDeviceTypeSerialnum = columnName,
                    WeatherStationSerialnum = stationSerialnum,
                    CreateTime = DateTime.Now
                };
                _weatherDeviceService.Add(device);
            }
        }

        /// <summary>
        /// 获取对应的机构编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private async Task<string> GetSysDepartmentSerialnum(string code)
        {
            //分析code
            var newCode = "58" + code.Substring(0, 3);
            var rws = await _areaStationService.GetByIdAsync(newCode);
            //查找机构编码
            if (rws != null && rws.SysDepartmentSerialnum != null)
            {
                return rws.SysDepartmentSerialnum;
            }

            return "";
        }

        /// <summary>
        /// 同步分钟数据
        /// </summary>
        /// <remarks>存储于分时数据表</remarks>
        private async Task<bool> SyncminuteData()
        {
#if DEBUG
            var watch = new Stopwatch();
            watch.Start();
#endif
            try
            {
                using (var connection = new SqlConnection(_connName))
                {
                    connection.Open();
                    var sqlda = new SqlDataAdapter(_tableNameSqlCmd, _connName);
                    var ds = new DataSet();
                    sqlda.Fill(ds, "TableNames");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var tName = dr[0].ToString();
                        //var cmd = "select * from " + tName;
                        var tableSchema = SqlHelper.GetTableMember(tName); //获取该表的结构
                        var dataAdapter = new SqlDataAdapter(tableSchema, connection);
                        var set = new DataSet();
                        dataAdapter.Fill(set, "Schema");
                        var schemas = set.Tables[0]; //该表字段的集合
                        //foreach (DataRow row in schemas.Rows)
                        //{
                        //    var t = row[0].ToString();
                        //}
                        var tableName = tName.Substring(1);
                        var station = await _weatherStationService.GetByIdAsync(tableName);
                        if (station == null)
                        {
                            //添加监测点信息
                            // station.Serialnum = tableName;
                            //return false;
                        }
                        else
                        {
                            var weatherDevices = await _weatherDeviceService.GetByStationIdAsny(station.Serialnum);
                            //if (weatherDevices.Count()==0 || !weatherDevices.Any())
                            //{
                            CreateWeatherDevice(schemas, tableName.ToString());
                            //}
                            //if (weatherDevices.Count()== 0)
                            ////Debugger.Break();
                            //{ }
                            //本地库中最后一行createtime
                            var createTime = DateTime.Now;
                            AreaStationDataInfoDto lastEntitys = null;
                            if (weatherDevices.Any())
                                lastEntitys =
                                    await _areaStationDataInfoService.GetByIdAsny(weatherDevices.ToList()[0].Serialnum);
                            if (lastEntitys != null)
                            {
                                createTime = Convert.ToDateTime(lastEntitys.CreateTime);
                            }
                            ////每次取100行数据
                            //var selectSql = "select top 100 * from " + tName + " where TT > '" + createTime.ToString() + "'";
                            //SqlDataAdapter adapter = new SqlDataAdapter(selectSql, connection);
                            //DataSet dataSet = new DataSet();
                            //dataAdapter.Fill(dataSet, "Table");

                            //if (dataSet != null && dataSet.Tables.Count > 0)
                            //{
                            //    //using (var tran = WeatherDeviceDataInfo.Meta.CreateTrans())
                            //    {
                            //        if (dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
                            //        {
                            //            var rows = dataSet.Tables[0].Rows;
                            //            foreach (DataRow row in rows)
                            //            {
                            //                try
                            //                {
                            //                   foreach( DataColumn col in schemas.Columns)
                            //                    {
                            //                        //排除列
                            //                        if ( _weatherDeviceTypeService.GetByIdAsny(col.ColumnName.ToUpper()) == null)
                            //                        {
                            //                            //暂不作任何处理
                            //                            //ServiceLogger.Current.WriteDebugLog(col.Name.ToUpper());
                            //                        }
                            //                        else
                            //                        {

                            //                        }
                            //                    }
                            //                }
                            //                catch (Exception ex)
                            //                {
                            //                    return false;
                            //                }

                            //            }
                            //        }
                            //        //tran.Commit();
                            //    }
                            //}
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                XTrace.WriteException(ex);
            }
#if DEBUG
            watch.Stop();
            LogHelper.Debug("同步农田小气候仪数据耗时：" + watch.ElapsedMilliseconds + "ms");
#endif
        }
    }
}