#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： AwApplication.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-03 14:25
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AhnqIot.Bussiness.Interface;
using AhnqIot.Infrastructure.DI;
using AhnqIot.Infrastructure.Log;
using Autofac;
using NewLife.Net;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Meta;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Collect;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Manage;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Query;
using SmartIot.API.ProcessorV2.ProtocalDataProcess.Control;

#endregion

namespace SmartIot.API.ProcessorV2.Core
{
    /// <summary>
    /// 数据解析应用程序
    /// </summary>
    public class AwApplication
    {
        #region ctor

        public AwApplication(DataPacket package)
        {
            RequestWrapper = package;
            _farmService = AhnqIotContainer.Container.Resolve<IFarmService>();
        }

        #endregion

        #region Field

        private readonly IFarmService _farmService;

        private AwEntity _awEntity;

        #endregion

        #region Properties

        /// <summary>
        ///     请求数据封装
        /// </summary>
        public DataPacket RequestWrapper { get; set; }

        /// <summary>
        ///     返回数据封装
        /// </summary>
        public XResponseMessage ResponseWrapper { get; set; }

        /// <summary>
        ///     网络会话
        /// </summary>
        public ISocketSession SocketSession { get; set; }

        #endregion

        #region event

        public EventHandler<string> BeginProcessEntity { get; set; }
        public EventHandler<string> EndProcessEntity { get; set; }

        public EventHandler BeginProcessEncrypt { get; set; }
        public EventHandler EndProcessEncrypt { get; set; }

        public EventHandler<Source> BeginProcessSource { get; set; }
        public EventHandler<Source> EndProcessSource { get; set; }

        public EventHandler BeginProcessDataBlock { get; set; }
        public EventHandler EndProcessDataBlock { get; set; }

        #endregion

        #region 业务

        /// <summary>
        ///     处理网络数据包入口函数
        /// </summary>
        /// <returns></returns>
        public async Task ProcessAsync()
        {
            if (RequestWrapper == null) return;
            //获取网络会话
            var session = RemoteSessionHelper.GetSession(RequestWrapper.Id);
            if (session == null)
            {
                LogHelper.Error($"未找到网络会话{RequestWrapper.Id}");
                return;
            }
            SocketSession = session;

            //开始事件处理流程序

            #region 事件处理流程

            AwEntity entity;

            #region 实体检测

            if (!ProcessEntity()) return;

            #endregion

            #region 验证块

            //todo 检测加密
            //未处理
            //todo 检测校验
            //未处理 

            #endregion

            #region 数据对象

            var result = await ProcessDataBlockObject();
            if (!result) Response();

            #endregion

            #endregion
        }

        /// <summary>
        ///     检验实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool ProcessEntity()
        {
            if (RequestWrapper.Data.IsNullOrWhiteSpace())
            {
                ResponseWrapper = ResultHelper.CreateMessage("请提供有效的数据", ErrorType.NotSupportedProtocalType);
                Response();
                return false;
            }

            BeginProcessEntity?.Invoke(this, RequestWrapper.Data);

            //检测协议格式
            var entity = AwEntityHelper.GetAwEntity(RequestWrapper.Data);
            if (entity == null)
            {
                LogHelper.Error("[数据格式] {0}", RequestWrapper.Data);
                ResponseWrapper = ResultHelper.CreateMessage("数据格式错误", ErrorType.CanNotProcessRequestData);
                Response();
                return false;
            }
            //数据包描述信息
            LogHelper.Trace(entity.Description);
            //检测版本号
            if (!AwEntityHelper.CheckVersion(entity.Version))
            {
                LogHelper.Error("[协议版本] {0}错误", entity.Version);
                ResponseWrapper = ResultHelper.CreateMessage("协议版本错误", ErrorType.VersionError);
            }

            EndProcessEntity?.Invoke(this, RequestWrapper.Data);
            if (ResponseWrapper != null)
            {
                Response();
                return false;
            }

            _awEntity = entity;
            return true;
        }

        /// <summary>
        ///     处理数据区
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ProcessDataBlockObject()
        {
            var entity = _awEntity;
            if (entity.DataBlockObject == null)
            {
                ResponseWrapper = ResultHelper.CreateMessage("无数据对象块", ErrorType.NoContent);
                // Response();
                return false;
            }

            #region 数据来源检测

            if (entity.DataBlockObject.Source == null)
            {
                ResponseWrapper = ResultHelper.CreateMessage("数据来源数据块不存在", ErrorType.NoContent);
                //Response();
                return false;
            }

            //处理前准备
            BeginProcessSource?.Invoke(this, entity.DataBlockObject.Source);

            //检测FarmCode基地编码是否存在
            var farm = await _farmService.GetByIdAsync(entity.DataBlockObject.Source.FarmCode);
            if (farm == null)
            {
                ResponseWrapper = ResultHelper.CreateMessage("基地编码不存在", ErrorType.FarmNotExists);
                //Response();
                return false;
            }
            //检测FarmKey是否正确
            if (entity.DataBlockObject.Source.FarmKey.IsNullOrWhiteSpace() ||
                !farm.UploadPassword.Equals(entity.DataBlockObject.Source.FarmKey))
            {
                ResponseWrapper = ResultHelper.CreateMessage("基地授权码错误", ErrorType.AuthorizeFailed);
                //Response();
                return false;
            }

            //后续处理
            EndProcessSource?.Invoke(this, entity.DataBlockObject.Source);

            if (ResponseWrapper != null)
            {
                //Response();
                return false;
            }

            #endregion

            //时间检测:超过10分钟的数据包不作处理
            if (DateTime.Now.Subtract(entity.DataBlockObject.CreateTime).TotalMinutes > 10)
            {
                LogHelper.Debug("数据包超过10分钟,不作处理:{0}", RequestWrapper.Data);
                ResponseWrapper = ResultHelper.CreateMessage("数据包超过10分钟未处理");
                return false;
            }

            #region 处理核心数据内容

            var coreDataBlcok = entity.DataBlockObject.DataContentRequest;
            if (coreDataBlcok == null)
            {
                ResponseWrapper = ResultHelper.CreateMessage("数据内容块不存在", ErrorType.NoContent);
                //Response();
                return false;
            }

            #region 采集数据处理

            //采集数据处理
            if (coreDataBlcok.CollectDataBlock == null)
            {
            }
            else
            {
                var collectDataBlock = coreDataBlcok.CollectDataBlock;
                //传感器数据
                if (collectDataBlock.SensorDatas != null && collectDataBlock.SensorDatas.Any())
                {
                    var result =
                        await
                            AhnqIotContainer.Container.Resolve<SensorDataProcess>()
                                .ProcessAsync(collectDataBlock.SensorDatas);
                    if (result != null)
                    {
                        ResponseWrapper = result;
                        return false;
                    }
                }

                //多媒体数据
                //await AhnqIotContainer.Container.Resolve<MediaDataProcess>().ProcessAsync(collectDataBlock.MediaDatas);
                if (collectDataBlock.MediaDatas != null && collectDataBlock.MediaDatas.Any())
                {
                    LogHelper.Warn("不处理多媒体数据");
                }
                //图片数据
                if (collectDataBlock.PictureDatas != null && collectDataBlock.PictureDatas.Any())
                {
                    LogHelper.Warn("不处理图片数据");
                }
            }

            #endregion

            #region 控制数据处理

            //控制数据处理
            if (coreDataBlcok.ControlDataBlock == null)
            {
            }
            else
            {
                var controlDataBlock = coreDataBlcok.ControlDataBlock;
                var result =
                    await AhnqIotContainer.Container.Resolve<ControlDataProcess>().ProcessAsync(controlDataBlock);
                if (result != null)
                {
                    ResponseWrapper = result;
                    return false;
                }
            }

            #endregion

            #region 查询数据处理

            //查询数据处理
            if (coreDataBlcok.QueryDataBlock == null)
            {
            }
            else
            {
                var queryDataBlock = coreDataBlcok.QueryDataBlock;
                var result = await AhnqIotContainer.Container.Resolve<QueryDataProcess>().ProcessAsync(queryDataBlock);
                if (result != null)
                {
                    ResponseWrapper = result;
                    return false;
                }
            }

            #endregion

            #region 管理数据处理

            //管理数据处理
            if (coreDataBlcok.ManageDataBlock == null)
            {
            }
            else
            {
                var manageDataBlock = coreDataBlcok.ManageDataBlock;
                var result = await AhnqIotContainer.Container.Resolve<ManageDataProcess>().ProcessAsync(manageDataBlock);
                if (result != null)
                {
                    ResponseWrapper = result;
                    return false;
                }
            }

            #endregion

            #region 上传数据管理

            //上传数据管理
            if (coreDataBlcok.RuntimeDataBlock == null)
            {
            }
            else
            {
                var runtimeDataBlock = coreDataBlcok.RuntimeDataBlock;
            }

            #endregion

            #endregion

            return true;
        }


        /// <summary>
        ///     回发消息
        /// </summary>
        /// <param name="message"></param>
        public void Response(XResponseMessage message = null)
        {
            //if (SocketSession == null) return;
            //Monitor.Enter(SocketSession);
            //try
            //{
            //   SocketSession?.Send((message ?? ResponseWrapper).ToString());
            //}
            //catch (Exception e)
            //{
            //    // 异常处理代码
            //    LogHelper.Debug(e.ToString());
            //}
            //finally
            //{
            //    Monitor.Exit(SocketSession);  // 解除锁定  
            //}
            try
            {
                if (SocketSession == null || SocketSession.Disposed) return;
                lock (SocketSession)
                {
                    SocketSession?.Send((message ?? ResponseWrapper).ToString());
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            //finally
            //{
            //    Monitor.Exit(SocketSession);
            //}
        }

        #endregion
    }
}