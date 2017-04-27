//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： SecuritySignHelper.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 16:32
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace Ahnqiot.Web.Api.Providers
{
    public static class SecuritySignHelper
    {
        public const string Partner = "partner";
        public const string Sign = "sign";

        /// <summary>
        /// 获取防篡改签名，组织原始字符串的方式为：先get后post，该签名要求partner在加密时为全小写，同时该方法隐含要求parnter和sign必须通过QueryString方式传递
        /// </summary>
        /// <param name="getCollection">通过QueryString方式传递的键值集合,如果内部包含parnter或者sign，相关字段在组织原始字符串时将会被移除</param>
        /// <param name="partner">合作账号</param>
        /// <param name="partnerKey">合作Key</param>
        /// <param name="postCollection">通过Form方式传递的键值集合，如果包含parnter或者sign，此部分不会被做特殊处理</param>
        /// <returns></returns>
        public static string GetSecuritySign(this NameValueCollection getCollection, string partner, string partnerKey,
            NameValueCollection postCollection = null)
        {
            if (string.IsNullOrWhiteSpace(partner) || string.IsNullOrWhiteSpace(partnerKey))
            {
                throw new ArgumentNullException();
            }
            var dic = GetSortedDictionary(getCollection,
                (k) =>
                {
                //过滤partner及sign
                return string.Equals(k, Partner, StringComparison.OrdinalIgnoreCase)
                           || string.Equals(k, Sign, StringComparison.OrdinalIgnoreCase);
                });
            dic.Add(Partner, partner);
            var tmp = new StringBuilder();
            FillStringBuilder(tmp, dic); //将QueryString填入StringBuilder
            dic = GetSortedDictionary(postCollection);
            FillStringBuilder(tmp, dic); //将Form填入StringBuilder
            tmp.Append(partnerKey); //在尾部添加key
            tmp.Remove(0, 1); //移除第一个&
            return tmp.ToString().GetMD5_32(); //获取32位长度的Md5摘要
        }

        private static SortedDictionary<string, string> GetSortedDictionary(NameValueCollection collection,
            Func<string, bool> filter = null)
        {
            //获取排序的键值对
            var dic = new SortedDictionary<string, string>();
            if (collection != null && collection.Count > 0)
            {
                foreach (var k in collection.AllKeys)
                {
                    if (filter == null || !filter(k))
                    {
                        //如果没设置过滤条件或者无需过滤
                        dic.Add(k, collection[k]);
                    }
                }
            }
            return dic;
        }

        private static void FillStringBuilder(StringBuilder builder, SortedDictionary<string, string> dic)
        {
            foreach (var kv in dic)
            {
                builder.Append('&');
                builder.Append(kv.Key);
                builder.Append('=');
                builder.Append(kv.Value);
            } //按key顺序组织字符串
        }

        /// <summary>
        /// 获取32位长度的Md5摘要
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetMD5_32(this string inputStr, Encoding encoding = null)
        {
            RefEncoding(ref encoding);
            var data = GetMD5(inputStr, encoding);
            var tmp = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                tmp.Append(data[i].ToString("x2"));
            }
            return tmp.ToString();
        }

        private static byte[] GetMD5(string inputStr, Encoding encoding)
        {
            using (var md5Hash = MD5.Create())
            {
                return md5Hash.ComputeHash(encoding.GetBytes(inputStr));
            }
        }

        private static void RefEncoding(ref Encoding encoding)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
        }
    }
}

