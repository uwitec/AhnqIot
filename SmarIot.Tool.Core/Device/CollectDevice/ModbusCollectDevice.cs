using NewLife.Log;
using NewLife.Net;
using NewLife.Net.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SmartIot.Tool.Core.Device.CollectDevice
{
    public class ModbusCollectDevice : DeviceBase, ICollectDevice, IDisposable
    {
        private readonly ModbusMaster _master;

        public ModbusCollectDevice(ITransport transport, byte host, MBFunction function)
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
            this.Function = function;
            Registers = new List<int>();
            Values = new List<ushort>();
        }

        public byte Host { get; set; }

        public MBFunction Function { get; set; }

        public List<int> Registers { get; set; }

        public List<ushort> Values { get; set; }

        public bool Read()
        {
            if (_master == null) throw new NullReferenceException("_master");

            var minReg = Registers.Min();
            var maxReg = Registers.Max();
            var count = Convert.ToUInt16(maxReg - minReg + 1);

            try
            {
                //等300ms，有些设备需要休息时间，主要是新普惠的破设备太坑爹
                Thread.Sleep(300);
                //锁一下Transport，避免和其它的调用者发生冲突
                lock (Transport)
                    switch (Function)
                    {
                        case MBFunction.ReadInputs:
                            var inputsResult = _master.ReadInputs(minReg, count);
                            if (inputsResult == null) return false;
                            Values.Clear();
                            if (inputsResult.Any())
                                Values = inputsResult.Select(b => b ? (UInt16) 1 : (UInt16) 0).ToList();
                            break;

                        case MBFunction.ReadHoldingRegisters:
                            var holdingRegistersResult = _master.ReadHoldingRegisters(minReg, count);
                            if (holdingRegistersResult == null) return false;
                            Values.Clear();
                            if (holdingRegistersResult.Any())
                                Values = holdingRegistersResult.ToList();
                            break;

                        case MBFunction.ReadInputRegisters:
                            var inputRegistersResult = _master.ReadInputRegisters(minReg, count);
                            if (inputRegistersResult == null) return false;
                            Values.Clear();
                            if (inputRegistersResult.Any())
                                Values = inputRegistersResult.ToList();
                            break;

                        default:
                            return false;
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

        /// <summary>销毁</summary>说
        public void Dispose()
        {
            Dispose(true);
        }

        public void EnsureTransport(ITransport transport)
        {
            base.Transport = transport;
            _master.Transport = transport;
        }

        /// <summary>析构</summary>
        ~ModbusCollectDevice()
        {
            Dispose(false);
        }

        /// <summary>销毁</summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (disposing) GC.SuppressFinalize(this);

            Transport?.Dispose();
            if (Transport == null) return;
            lock (Transport)
            {
                _master?.Dispose();
            }
        }
    }
}