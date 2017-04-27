#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： ResumeSpeechSynthesis.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:25
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using NewLife.Model;
using System;

#endregion using namespace

namespace SmartIot.Tool.Core.Device.TtsDevice.KdxfProtocal
{
    /// <summary>
    ///     The resume speech synthesis.
    /// </summary>
    public class ResumeSpeechSynthesis : TtsEntity, IRequest
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="ResumeSpeechSynthesis" /> class.
        /// </summary>
        static ResumeSpeechSynthesis()
        {
            ObjectContainer.Current.Register<IRequest, ResumeSpeechSynthesis>(TtsFunction.ResumeSpeechSynthesis);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResumeSpeechSynthesis" /> class.
        /// </summary>
        public ResumeSpeechSynthesis()
        {
            Function = TtsFunction.ResumeSpeechSynthesis;
        }

        #endregion Constructors and Destructors

        #region Public Methods and Operators

        /// <summary>
        ///     The calculate extend data.
        /// </summary>
        public override void CalculateExtendData()
        {
            // base.CalculateExtendData();
            ExtendData.Clear();
            ExtendData.Add((byte) Function);
        }

        /// <summary>
        ///     The set args.
        /// </summary>
        /// <param name="args">
        ///     The args.
        /// </param>
        public override void SetArgs(params object[] args)
        {
            base.SetArgs(args);
        }

        #endregion Public Methods and Operators
    }
}