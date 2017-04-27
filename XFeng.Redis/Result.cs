#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： Result.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Smart.Redis
{
    public class Result : IDisposable
    {
        private int mBlockStartIndex = 0;

        private int mBufferOffset = 0;

        private byte[] mData = null;

        internal int mImportOffset = 0;

        private int mItemLength = 0;

        private LineBuffer mLineBuffer;

        private bool mReadCompleted = true;

        private int mResultCount = 0;

        private bool mSingle = true;

        private bool mValidLength = true;

        public Result()
        {
            mData = BufferPool.Single.Pop();
            mLineBuffer = LineBuffer.Pop();
        }

        public object ResultData { get; set; }

        public string Header { get; private set; } = null;

        public IList<ArraySegment<byte>> ResultDataBlock { get; set; }

        public void Dispose()
        {
            lock (this)
            {
                if (mData != null)
                {
                    var _data = mData;
                    var _lbuffer = mLineBuffer;
                    mData = null;
                    mLineBuffer = null;
                    BufferPool.Single.Push(_data);
                    LineBuffer.Push(_lbuffer);
                }
            }
        }

        internal bool Import(byte[] data, int offset, int count)
        {
            offset += mImportOffset;
            count -= mImportOffset;
            while (count > 0)
            {
                if (Header == null)
                {
                    if (mLineBuffer.Import(data, ref offset, ref count))
                    {
                        Header = mLineBuffer.GetLineString();
                        if (Header[0] == '+')
                        {
                            ResultData = Header.Substring(1, Header.Length - 1);
                            return true;
                        }
                        else if (Header[0] == '-')
                        {
                            throw new Exception(Header.Substring(1, Header.Length - 1));
                        }
                        else if (Header[0] == '$')
                        {
                            mResultCount = 1;
                            mSingle = true;
                            mItemLength = int.Parse(Header.Substring(1, Header.Length - 1));
                        }
                        else if (Header[0] == '*')
                        {
                            mResultCount = int.Parse(Header.Substring(1, Header.Length - 1));
                            mSingle = false;
                        }
                        else if (Header[0] == ':')
                        {
                            ResultData = Header.Substring(1, Header.Length - 1);
                            return true;
                        }
                        else
                        {
                            throw new Exception($"header error:{Header}");
                        }
                        ResultDataBlock = new List<ArraySegment<byte>>(mResultCount);
                        mLineBuffer.Reset();
                    }
                }
                if (mResultCount == 0)
                    break;
                mValidLength = true;
                //if (mItemLength == 0 && mResultCount >0)
                if (!mSingle && mResultCount > 0 && mReadCompleted)
                {
                    mValidLength = mLineBuffer.Import(data, ref offset, ref count);
                    if (mValidLength)
                    {
                        string line;
                        try
                        {
                            line = mLineBuffer.GetLineString();
                            mItemLength = int.Parse(line.Substring(1, line.Length - 3));
                            mLineBuffer.Reset();
                        }
                        catch (Exception e_)
                        {
                            throw e_;
                        }
                    }
                }
                if (mValidLength)
                {
                    LoadData(data, ref offset, ref count);
                }
            }

            if (count < 0)
                mImportOffset = Math.Abs(count);
            else
                mImportOffset = 0;
            return mItemLength == 0 && mResultCount == 0;
        }

        private void LoadData(byte[] data, ref int offset, ref int count)
        {
            try
            {
                mReadCompleted = true;
                if (mItemLength == -1)
                {
                    ResultDataBlock.Add(new ArraySegment<byte>(mData, mBlockStartIndex, 0));
                    mItemLength = 0;
                    mResultCount--;
                    return;
                }
                if (mItemLength == 0)
                {
                    ResultDataBlock.Add(new ArraySegment<byte>(mData, mBlockStartIndex, 0));
                    offset += 2;
                    count -= 2;
                    mResultCount--;
                    return;
                }
                if (count >= mItemLength)
                {
                    Buffer.BlockCopy(data, offset, mData, mBufferOffset, mItemLength);
                    offset += (mItemLength + 2);
                    count -= (mItemLength + 2);
                    mBufferOffset += mItemLength;
                    ResultDataBlock.Add(new ArraySegment<byte>(mData, mBlockStartIndex, mBufferOffset - mBlockStartIndex));
                    mBlockStartIndex = mBufferOffset;
                    mItemLength = 0;
                    mResultCount--;
                }
                else
                {
                    Buffer.BlockCopy(data, offset, mData, mBufferOffset, count);
                    mBufferOffset += count;
                    offset += count;
                    mItemLength -= count;
                    count = 0;
                    mReadCompleted = false;
                }
            }
            catch (Exception e_)
            {
                throw new Exception("buffer overflow buffer max size:" + BufferPool.DEFAULT_BUFFERLENGTH, e_);
            }
        }

        private string ReadLine(byte[] data, ref int offset, ref int count)
        {
            var start = offset;
            while (count > 1)
            {
                if (data[offset] == Utils.Eof[0] && data[offset + 1] == Utils.Eof[1])
                {
                    offset += 2;
                    count -= 2;
                    return Encoding.ASCII.GetString(data, start, offset - start - 2);
                }
                else
                {
                    offset += 1;
                    count -= 1;
                }
            }
            return null;
        }
    }
}