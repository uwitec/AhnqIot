#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： BufferPool.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Concurrent;

#endregion

namespace Smart.Redis
{
    public class BufferPool
    {
        public static int DEFAULT_BUFFERLENGTH = 1024*1024*2;

        private static BufferPool mSingle;

        private readonly int mBufferLength = 1024;

        private readonly ConcurrentStack<byte[]> mPools = new ConcurrentStack<byte[]>();

        public BufferPool(int count, int bufferlength)
        {
            for (var i = 0; i < count; i++)
            {
                mPools.Push(new byte[bufferlength]);
            }
            mBufferLength = bufferlength;
        }

        public static BufferPool Single
        {
            get
            {
                if (mSingle == null)
                {
                    mSingle = new BufferPool(20, DEFAULT_BUFFERLENGTH);
                }
                return mSingle;
            }
        }

        public byte[] Pop()
        {
            byte[] result = null;
            if (mPools.TryPop(out result))
            {
                return result;
            }
            else
            {
                return new byte[mBufferLength];
            }
        }

        public void Push(byte[] data)
        {
            mPools.Push(data);
        }
    }
}