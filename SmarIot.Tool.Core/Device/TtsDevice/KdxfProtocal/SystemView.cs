#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： SystemView.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-06 1:25
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

#region using namespace

using NewLife.Model;
using System;

#endregion using namespace

namespace SmartIot.Tool.Core.Device.TtsDevice.KdxfProtocal
{
    /// <summary>
    ///     The system view.
    /// </summary>
    public class SystemView : TtsEntity, IRequest
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="SystemView" /> class.
        /// </summary>
        static SystemView()
        {
            ObjectContainer.Current.Register<IRequest, SystemView>(TtsFunction.SystemView);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SystemView" /> class.
        /// </summary>
        public SystemView()
        {
            Function = TtsFunction.SystemView;
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