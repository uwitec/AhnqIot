#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： SpeechSynthesis.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:25
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using NewLife.Model;
using System;
using System.Collections.Generic;

#endregion using namespace

namespace SmartIot.Tool.Core.Device.TtsDevice.KdxfProtocal
{
    /// <summary>
    ///     The speech synthesis.
    /// </summary>
    public class SpeechSynthesis : TtsEntity, IRequest
    {
        #region Fields

        /// <summary>
        ///     The _ data length.
        /// </summary>
        private ushort _dataLength;

        /// <summary>
        ///     The _ data.
        /// </summary>
        [NonSerialized] private List<byte> _data;

        #endregion Fields

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="SpeechSynthesis" /> class.
        /// </summary>
        static SpeechSynthesis()
        {
            ObjectContainer.Current.Register<IRequest, SpeechSynthesis>(TtsFunction.SpeechSynthesis);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpeechSynthesis" /> class.
        /// </summary>
        public SpeechSynthesis()
        {
            Function = TtsFunction.SpeechSynthesis;
            _data = new List<byte>();
        }

        #endregion Constructors and Destructors

        #region Public Properties

        /// <summary>
        ///     数据长度
        /// </summary>
        public ushort DataLength
        {
            get { return _dataLength; }

            set { _dataLength = value; }
        }

        /// <summary>
        ///     待合成二进制文本
        /// </summary>
        public List<byte> Data
        {
            get { return _data; }

            set
            {
                _data = value;
                DataLength = (ushort) (_data.Count + 1);
            }
        }

        #endregion Public Properties

        #region Public Methods and Operators

        /// <summary>
        ///     The calculate extend data.
        /// </summary>
        public override void CalculateExtendData()
        {
            // base.CalculateExtendData();
            ExtendData.Clear();
            DataLength = Convert.ToUInt16(Data.Count + 2);
            var temp = BitConverter.GetBytes(DataLength);
            Array.Reverse(temp);
            ExtendData.AddRange(temp);
            ExtendData.Add((byte) Function);
            ExtendData.Add(0x01);
            ExtendData.AddRange(_data);
        }

        /// <summary>
        ///     The set args.
        /// </summary>
        /// <param name="args">
        ///     The args.
        /// </param>
        public override void SetArgs(params object[] args)
        {
            // base.SetArgs(args);
            if (args != null) _data = new List<byte>((byte[]) args[0]);
        }

        #endregion Public Methods and Operators
    }
}