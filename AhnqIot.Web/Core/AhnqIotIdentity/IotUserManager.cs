#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： IotUserManager .cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-15 15:47
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Security.Cryptography;
using Microsoft.AspNet.Identity;

#endregion

namespace AhnqIot.Web.Core.AhnqIotIdentity
{
    public class IotUserManager : UserManager<IotUser, String>
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="store"></param>
        public IotUserManager(IotUserStore store)
            : base(store)
        {
            //采用老的加密程序
            PasswordHasher = new OldSystemPasswordHasher();
        }

        /// <summary>
        ///     Use Custom approach to verify password
        /// </summary>
        public class OldSystemPasswordHasher : PasswordHasher
        {
            /// <summary>
            ///     对密码进行Hash加密
            /// </summary>
            /// <param name="password"></param>
            /// <returns></returns>
            public override string HashPassword(string password)
            {
                byte[] salt;
                byte[] buffer2;
                if (password == null)
                {
                    throw new ArgumentNullException("password");
                }
                using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
                {
                    salt = bytes.Salt;
                    buffer2 = bytes.GetBytes(0x20);
                }
                var dst = new byte[0x31];
                Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
                Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
                return Convert.ToBase64String(dst);
            }

            /// <summary>
            ///     重写验证密码的方法
            /// </summary>
            /// <param name="hashedPassword">加密后的密码</param>
            /// <param name="providedPassword">提供的密码</param>
            /// <returns></returns>
            public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
            {
                byte[] buffer4;
                if (hashedPassword == null)
                {
                    return PasswordVerificationResult.Failed;
                }
                if (string.IsNullOrEmpty(providedPassword))
                {
                    throw new ArgumentNullException("providedPassword");
                }
                var src = Convert.FromBase64String(hashedPassword);
                if ((src.Length != 0x31) || (src[0] != 0))
                {
                    return PasswordVerificationResult.Failed;
                }
                var dst = new byte[0x10];
                Buffer.BlockCopy(src, 1, dst, 0, 0x10);
                var buffer3 = new byte[0x20];
                Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
                using (var bytes = new Rfc2898DeriveBytes(providedPassword, dst, 0x3e8))
                {
                    buffer4 = bytes.GetBytes(0x20);
                }

                if (ByteEqual(buffer3, buffer4))
                {
                    return PasswordVerificationResult.Success;
                }
                else
                {
                    return PasswordVerificationResult.Failed;
                }
            }

            /// <summary>
            ///     比较两个字节数组
            /// </summary>
            /// <param name="b1"></param>
            /// <param name="b2"></param>
            /// <returns></returns>
            private static bool ByteEqual(byte[] b1, byte[] b2)
            {
                if (b1.Length != b2.Length) return false;
                if (b1 == null || b2 == null) return false;
                for (var i = 0; i < b1.Length; i++)
                {
                    if (b1[i] != b2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}