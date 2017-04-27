#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： NameType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

namespace Smart.Redis
{
    public class NameType
    {
        public int Index;
        public string Name;

        public NameType(string key, int index)
        {
            Name = key;
            Index = index;
        }
    }
}