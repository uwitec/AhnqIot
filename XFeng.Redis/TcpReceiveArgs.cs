#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： TcpReceiveArgs.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
//********************************************************
// 	Copyright © henryfan 2013		 
//	Email:		henryfan@msn.com	
//	HomePage:	http://www.ikende.com		
//	CreateTime:	2013/6/15 14:55:21
//********************************************************	 

#endregion

namespace Smart.Redis
{
    public class TcpReceiveArgs : EventArgs
    {
        public TcpClient Client { get; internal set; }

        public byte[] Data { get; internal set; }

        public int Offset { get; internal set; }

        public int Count { get; internal set; }

        public byte[] ToArray()
        {
            var result = new byte[Count];
            Buffer.BlockCopy(Data, Offset, result, 0, Count);
            return result;
        }

        public void CopyTo(byte[] data, int start = 0)
        {
            Buffer.BlockCopy(Data, Offset, data, start, Count);
        }
    }
}