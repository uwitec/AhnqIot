#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： StringEncoding.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Text;

#endregion

namespace Smart.Redis
{
    class StringEncoding
    {
        public byte[] Buffer;

        public StringEncoding(int length)
        {
            Buffer = new byte[length];
        }


        public int Encode(string value)
        {
            var count = Encoding.UTF8.GetBytes(value, 0, value.Length, Buffer, 0);
            return count;
        }
    }
}