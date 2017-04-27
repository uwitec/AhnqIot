#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.Core
// FILENAME   ： ModbusControlDevice.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-04 23:09
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using NewLife.Log;
using NewLife.Net;
using NewLife.Net.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SmartIot.Tool.Core.Device.ControlDevice
{
    public class ModbusControlDevice : DeviceBase, IControlDevice
    {
        private readonly ModbusMaster _master;

        public ModbusControlDevice(ITransport transport, byte host)
        {
            if (transport == null)
                throw new ArgumentNullException(nameof(transport));
            if (base.Transport == null)
                base.Transport = transport;
            if (_master == null)
            {
                _master = new ModbusMaster
                {
                    Transport = base.Transport,
                    Host = host
#if DEBUG
                    ,
                    EnableDebug = true
#endif
                };
            }
            this.Host = host;
            Registers = new List<int>();
            Values = new List<bool>();
        }

        public byte Host { get; set; }

        public List<int> Registers { get; set; }

        public List<bool> Values { get; set; }

        public bool Read()
        {
            if (_master == null) throw new NullReferenceException("_master");

            var minReg = Registers.Min();
            var maxReg = Registers.Max();
            var count = Convert.ToUInt16(maxReg - minReg + 1);

            try

            {
                Thread.Sleep(3000);
                //锁一下Transport，避免和其它的调用者发生冲突
                lock (Transport)
                {
                    var inputsResult = _master.ReadCoils(minReg, count);
                    if (inputsResult == null) return false;
                    Values.Clear();
                    if (inputsResult.Any())
                        Values = inputsResult.ToList();
                }
                return true;
            }
            catch (ObjectDisposedException odx)
            {
                throw odx;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }

        public bool Write(int addr, bool status)
        {
            if (_master == null) throw new NullReferenceException("_master");

            try
            {
                //锁一下Transport，避免和其它的调用者发生冲突
                lock (Transport)
                {
                    return _master.WriteSingleCoil(addr, status);
                }
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }

        public bool Write(int addr, bool[] status)
        {
            if (_master == null) throw new NullReferenceException("_master");

            try
            {
                //锁一下Transport，避免和其它的调用者发生冲突
                lock (Transport)
                {
                    return _master.WriteMultipleCoils(addr, status);
                }
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }

        public void EnsureTransport(ITransport transport)
        {
            base.Transport = transport;
            _master.Transport = transport;
        }
    }
}