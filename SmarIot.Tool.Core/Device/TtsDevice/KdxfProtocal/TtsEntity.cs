#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： TtsEntity.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:25
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using NewLife;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

#endregion using namespace

namespace SmartIot.Tool.Core.Device.TtsDevice.KdxfProtocal
{
    /// <summary>
    ///     The tts entity.
    /// </summary>
    public class TtsEntity
    {
        #region Methods

        /// <summary>
        ///     初始化
        /// </summary>
        private static void Init()
        {
            var container = ObjectContainer.Current;
            var asm = Assembly.GetExecutingAssembly();

            // 搜索已加载程序集里面的消息类型
            foreach (var item in AssemblyX.FindAllPlugins(typeof (IRequest), true))
            {
                var msg = TypeX.CreateInstance(item) as IRequest;
                if (msg != null)
                {
                    container.Register(typeof (IRequest), item, null, msg.Function);
                }
            }

            foreach (var item in AssemblyX.FindAllPlugins(typeof (IResponse), true))
            {
                var msg = TypeX.CreateInstance(item) as IResponse;
                if (msg != null)
                {
                    container.Register(typeof (IResponse), item, null, msg.Function);
                }
            }
        }

        #endregion Methods

        #region Fields

        /// <summary>
        ///     The _ extend data.
        /// </summary>
        [NonSerialized] [FieldSize("_DataLength")] private List<byte> _extendData;

        /// <summary>
        ///     The _ function.
        /// </summary>
        [NonSerialized] private TtsFunction _function;

        #endregion Fields

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="TtsEntity" /> class.
        /// </summary>
        static TtsEntity()
        {
            Init();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TtsEntity" /> class.
        /// </summary>
        public TtsEntity()
        {
            _extendData = new List<byte>();

            Header = 0xFD;
            // 默认功能码为命成语音
            _function = TtsFunction.SpeechSynthesis;
        }

        #endregion Constructors and Destructors

        #region Public Properties

        /// <summary>
        ///     数据区
        /// </summary>
        public List<byte> ExtendData
        {
            get { return _extendData; }

            set { _extendData = value; }
        }

        /// <summary>
        ///     命令字
        /// </summary>
        public TtsFunction Function
        {
            get { return _function; }

            set { _function = value; }
        }

        /// <summary>
        ///     包头 0xFD
        /// </summary>
        public byte Header { get; set; }

        #endregion Public Properties

        #region Public Methods and Operators

        /// <summary>
        ///     将数据区按各自的要求进行转换
        /// </summary>
        public virtual void CalculateExtendData()
        {
            throw new NotImplementedException("CalculateExtendData");
        }

        /// <summary>
        ///     序列化为数据流
        /// </summary>
        /// <returns>
        ///     The <see cref="Stream" />.
        /// </returns>
        public Stream GetStream()
        {
            var ms = new MemoryStream();
            Write(ms);
            ms.Position = 0;
            return ms;
        }

        /// <summary>
        ///     从流中读取消息
        /// </summary>
        /// <param name="stream">
        /// </param>
        /// <returns>
        ///     The <see cref="EntityBase" />.
        /// </returns>
        public static TtsEntity Read(Stream stream)
        {
            var ms = stream;
            var start = ms.Position;
            ms.Position = 0;

            // 读取命令码
            var function = (TtsFunction) ms.ReadByte();
            // 读取了响应类型和消息类型后，动态创建消息对象
            var type = ObjectContainer.Current.ResolveType<IResponse>(function);
            var entity = TypeX.CreateInstance(type) as TtsEntity;
            entity.Function = function;
            return entity;
        }

        /// <summary>
        ///     从流中读取消息
        /// </summary>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <param name="stream">
        /// </param>
        /// <returns>
        ///     The <see cref="TEntity" />.
        /// </returns>
        public static TEntity Read<TEntity>(Stream stream) where TEntity : TtsEntity
        {
            return Read(stream) as TEntity;
        }

        /// <summary>
        ///     The set args.
        /// </summary>
        /// <param name="args">
        ///     The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public virtual void SetArgs(params object[] args)
        {
            throw new NotImplementedException("SetArgs");

            // if (args.Length == 1)
            // SubCmd = (LType.SubCmdType)Enum.Parse(typeof(LType.SubCmdType), args[0].ToString());
        }

        /// <summary>
        ///     把当前对象写入数据，包括可能的起始符和结束符
        /// </summary>
        /// <param name="stream">
        /// </param>
        public void Write(Stream stream)
        {
            //// Default模式，先写入内存流
            //var ms = new MemoryStream();
            //var writer = new BinaryWriterX(ms);
            //Set(writer);
            //writer.Settings.IsLittleEndian = false;
            //ms.Position = 0;

            ////writer.WriteObject(this);
            //writer.Write(Header);

            //var dt = ExtendData;
            //if (dt != null && dt.Count > 0)
            //{
            //    writer.Write(dt.ToArray<byte>(), 0, dt.Count);
            //}

            //ms.Position = 0;
            //var data = ms.ReadBytes();
            //writer.Stream = stream;
            ////writer.Write(data, 0, data.Length);

            //ms.Position = 0;
            //ms.CopyTo(stream);

            var list = new List<byte>();
            list.Add(Header);
            list.AddRange(ExtendData);
            stream.Position = 0;
            stream.Write(list.ToArray(), 0, list.Count);
        }

        #endregion Public Methods and Operators
    }
}