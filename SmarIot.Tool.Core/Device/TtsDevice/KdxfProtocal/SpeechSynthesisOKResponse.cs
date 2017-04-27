#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： SpeechSynthesisOKResponse.cs
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
    ///     The speech synthesis ok response.
    /// </summary>
    public class SpeechSynthesisOKResponse : TtsEntity, IResponse
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="SpeechSynthesisOKResponse" /> class.
        /// </summary>
        static SpeechSynthesisOKResponse()
        {
            ObjectContainer.Current.Register<IResponse, SpeechSynthesisOKResponse>(
                TtsFunction.SpeechSynthesisOKResponse);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpeechSynthesisOKResponse" /> class.
        /// </summary>
        public SpeechSynthesisOKResponse()
        {
            Function = TtsFunction.SpeechSynthesisOKResponse;
        }

        #endregion Constructors and Destructors

        #region Public Methods and Operators

        /// <summary>
        ///     The calculate extend data.
        /// </summary>
        public override void CalculateExtendData()
        {
            // base.CalculateExtendData();
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