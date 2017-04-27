using System;
using System.Linq;
using System.Text;
using System.Xml;
using AhnqIot.AreaStationDataProcess.AHNQ.Weather;
using AhnqIot.Bussiness.Interface;
using AhnqIot.DataProcess.Service.Core;
using AhnqIot.Dto;
using AhnqIot.Infrastructure.DI;
using Autofac;
using NewLife.Log;

namespace AhnqIot.AreaStationDataProcess
{
    public class AreaStationJob : Job
    {
        //private TimerX _timer;

        //public override string DisplayName { get { return "农气物联网--关联气象站数据插件"; } }
        private readonly IAreaStationService _areaStationService;
        private readonly IAreaStationDataInfoService _areaStationDataInfoService;

        public AreaStationJob()
        {
            DisplayName = "区域气象站数据工作组件";
            JobInterval = 30 * 60;
            _areaStationService = AhnqIotContainer.Container.Resolve<IAreaStationService>();
            _areaStationDataInfoService = AhnqIotContainer.Container.Resolve<IAreaStationDataInfoService>();
        }

        public override bool Start()
        {
            Collect();
            var result = base.Start();
            // _timer = new TimerX(obj => Collect(), null, 5000, 30 * 60 * 1000);
            //WriteLog("区域气象站启动");
            return result;
        }

        public override bool Work()
        {
            Collect();
            return base.Work();
        }

        public override bool Stop()
        {
            //var result = base.Stop();
            //_timer.Dispose();

            //return result;
            //WriteLog("区域气象站停止");
            return base.Stop();
        }

        private async void Collect()
        {
            try
            {
                var list =await _areaStationService.GetAllAsync();
                list.ToList().ForEach(async rws =>
                {
                    StringBuilder sb = new StringBuilder();
                    WebServiceSoapClient client = new WebServiceSoapClient();
                    XmlDocument doc = new XmlDocument();
                    var stationId = rws.StationCode;
                    var xml = client.getWeather(stationId);
                    doc.LoadXml(xml);
                    XmlNodeList nodeList = doc.GetElementsByTagName("ds");
                    if (nodeList != null)
                    {
                        // int wind = 0;
                        DateTime time = DateTime.Now;
                        if (DateTime.TryParse(nodeList[0].ChildNodes[0].InnerText, out time))
                        {
                            try
                            {
                                string rain = nodeList[0].ChildNodes[1].InnerText;
                                //wind = int.Parse(nodeList[0].ChildNodes[2].InnerText);
                                ////wind = 359;
                                //int direction = wind / 45;
                                //if (wind % 45 != 0 && direction % 2 == 0)
                                //{
                                //    direction += 1;
                                //}
                                //if (wind == 360)
                                //{
                                //    direction = 0;
                                //}
                                //string windDirection = Enum.GetName(typeof(WindDirectionEightEnum), direction);
                                string windDirection = nodeList[0].ChildNodes[2].InnerText;
                                string windSpeed = nodeList[0].ChildNodes[3].InnerText;
                                string temprature = nodeList[0].ChildNodes[4].InnerText;
                                string humidity = nodeList[0].ChildNodes[5].InnerText;
                                string pressure = nodeList[0].ChildNodes[6].InnerText;

                                rws.Temprature = temprature.IsNullOrWhiteSpace() ? 0M : Convert.ToDecimal(temprature);
                                rws.Humidity = humidity.IsNullOrWhiteSpace() ? 0M : Convert.ToDecimal(humidity);
                                rws.Rainfall = rain.IsNullOrWhiteSpace() ? 0M : Convert.ToDecimal(rain);
                                rws.WindSpeed = windSpeed.IsNullOrWhiteSpace() ? 0M : Convert.ToDecimal(windSpeed);
                                rws.WindDirection = 0;//direction;
                                rws.Atmosphere = pressure.IsNullOrWhiteSpace() ? 0M : Convert.ToDecimal(pressure);
                                rws.UpdateTime = time;
                                rws.Remark = windDirection;
                                await _areaStationService.UpdateAsync(rws);

                                AreaStationDataInfoDto di = new AreaStationDataInfoDto();
                                di.Serialnum = rws.StationCode + "-" + DateTime.Now.ToString("O");
                                di.AreaStationSerialnum = rws.Serialnum;
                                di.Temprature = Convert.ToDecimal(temprature);
                                di.Humidity = Convert.ToDecimal(humidity);
                                di.Rainfall = Convert.ToDecimal(rain);
                                di.WindSpeed = Convert.ToDecimal(windSpeed);
                                di.WindDirection = 0;//direction;
                                di.Atmosphere = Convert.ToDecimal(pressure);
                                di.CreateTime = time;
                                di.UpdateTime = DateTime.Now;
                                di.Remark = windDirection;
                                di.Sort = 0;
                                await _areaStationDataInfoService.AddAsny(di);
                            }
                            catch (Exception ex)
                            {
                                XTrace.WriteLine(ex.Message);
                                XTrace.WriteLine("接口返回XML为:" + xml);
                            }
                        }
                    }
                });

                //list.Save(true);
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }
        }
    }
}